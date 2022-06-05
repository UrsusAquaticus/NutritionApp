using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class IngredientsPageViewModel : BaseViewModel
    {
        //https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
        //Look here for how to implement the custom interface 'IPageService'
        private IngredientVM _selectedIngredient;
        private IDataStore<Ingredient> _ingredientStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        private ObservableCollection<IngredientVM> _ingredients { get; set; } = new ObservableCollection<IngredientVM>();
        public ObservableCollection<IngredientVM> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        public IngredientVM SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { SetValue(ref _selectedIngredient, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddIngredientCommand { get; private set; }
        public ICommand SelectIngredientCommand { get; private set; }
        public ICommand DeleteIngredientCommand { get; private set; }
        public ICommand FilterIngredientCommand { get; private set; }

        public IngredientsPageViewModel(IDataStore<Ingredient> ingredientStore, IPageService pageService)
        {
            _ingredientStore = ingredientStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddIngredientCommand = new Command(async () => await AddIngredient());
            SelectIngredientCommand = new Command<IngredientVM>(async c => await SelectIngredient(c));
            DeleteIngredientCommand = new Command<IngredientVM>(async c => await DeleteIngredient(c));
            FilterIngredientCommand = new Command<string>(async c => await FilterIngredient(c));

            MessagingCenter.Subscribe<IngredientDetailPageViewModel, Ingredient>(this, Events.IngredientAdded, OnIngredientAdded);
            MessagingCenter.Subscribe<IngredientDetailPageViewModel, Ingredient>(this, Events.IngredientUpdated, OnIngredientUpdated);
        }

        private void OnIngredientAdded(IngredientDetailPageViewModel source, Ingredient ingredient)
        {
            Ingredients.Add(new IngredientVM(ingredient));
        }
        private void OnIngredientUpdated(IngredientDetailPageViewModel source, Ingredient ingredient)
        {
            var ingredientInList = Ingredients.Single(c => c.Id == ingredient.Id);
            ingredientInList.Name = ingredient.Name;
            ingredientInList.ServingSizeGrams = ingredient.ServingSizeGrams;
            ingredientInList.Kj = ingredient.Kj;

        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            var ingredients = await _ingredientStore.GetAsync();
            foreach (var ingredient in ingredients)
                Ingredients.Add(new IngredientVM(ingredient));
        }

        private async Task AddIngredient()
        {
            await _pageService.PushAsync(new IngredientDetailPage(new IngredientVM()));
            //await _profileStore.AddAsync(new Profile { Id = 1, Name = "Zach", Pregnant = true }); //temp, have not implemented messaging to update list yet. Requires app reload to view changes
        }

        private async Task SelectIngredient(IngredientVM ingredient)
        {
            if (ingredient == null)
                return;
            SelectedIngredient = null;
            await _pageService.PushAsync(new IngredientDetailPage(ingredient));
        }

        private async Task DeleteIngredient(IngredientVM ingredientVM)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {ingredientVM.Name}?", "Yes", "No"))
            {
                Ingredients.Remove(ingredientVM);
                var ingredient = await _ingredientStore.GetAsync(ingredientVM.Id);
                await _ingredientStore.DeleteAsync(ingredient.Id);
            }
        }

        // perform search using a viewmodel... https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar#perform-a-search-using-a-viewmodel
        public async Task FilterIngredient(string queryString)
        {
            // check if queryString is null, if not put to lower, if null return empty string
            var normalizedQuery = queryString?.ToLower() ?? "";
            var ingredients = await _ingredientStore.GetAsync();
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                ingredients = ingredients.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery));
            }
            Ingredients.Clear();
            foreach (var ingredient in ingredients)
                Ingredients.Add(new IngredientVM(ingredient));
        }
    }
}
