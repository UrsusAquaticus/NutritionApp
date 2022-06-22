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
        private readonly IDataStore<Ingredient> _ingredientStore;
        private readonly IPageService _pageService;
        private bool _isDataLoaded;

        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        private Ingredient selectedIngredient;

        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
            set
            {
                SetValue(ref ingredients, value);
            }
        }
        public Ingredient SelectedIngredient
        {
            get { return selectedIngredient; }
            set { SetValue(ref selectedIngredient, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddIngredientCommand { get; private set; }
        public ICommand SelectIngredientCommand { get; private set; }
        public ICommand DeleteIngredientCommand { get; private set; }
        public ICommand FilterIngredientCommand { get; private set; }

        public IngredientsPageViewModel(IDataStore<Ingredient> ingredientStore, IPageService pageService)
        {
            _pageService = pageService;
            _ingredientStore = ingredientStore;

            LoadDataCommand = new Command(async () => await LoadData());
            AddIngredientCommand = new Command(async () => await AddIngredient());
            SelectIngredientCommand = new Command<Ingredient>(async c => await SelectIngredient(c));
            DeleteIngredientCommand = new Command<Ingredient>(async c => await DeleteIngredient(c));
            FilterIngredientCommand = new Command<string>(async c => await FilterIngredient(c));

            MessagingCenter.Subscribe<object, Ingredient>(this, Events.IngredientAdded, OnIngredientAdded);
            MessagingCenter.Subscribe<object, Ingredient>(this, Events.IngredientUpdated, OnIngredientUpdated);
        }

        private void OnIngredientAdded(object source, Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
        private void OnIngredientUpdated(object source, Ingredient ingredient)
        {
            var ingredientInList = Ingredients.Single(c => c.Id == ingredient.Id);
            ingredientInList = ingredient;

        }

        public async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            var ingredients = await _ingredientStore.GetAsync();
            foreach (var ingredient in ingredients)
                Ingredients.Add(ingredient);
        }

        private async Task AddIngredient()
        {
            await _pageService.PushAsync(new IngredientDetailPage(new Ingredient()));
        }

        private async Task SelectIngredient(Ingredient ingredient)
        {
            if (ingredient == null)
                return;
            SelectedIngredient = null;
            await _pageService.PushAsync(new IngredientDetailPage(ingredient));
        }

        private async Task DeleteIngredient(Ingredient ingredient)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {ingredient.Name}?", "Yes", "No"))
            {
                Ingredients.Remove(ingredient);
                await _ingredientStore.DeleteAsync(ingredient);
            }
        }

        // perform search using a viewmodel... https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar#perform-a-search-using-a-viewmodel
        public async Task FilterIngredient(string queryString)
        {
            // check if queryString is null, if not put to lower, if null return empty string
            var normalizedQuery = queryString?.ToLower() ?? "";
            var _ingredients = await _ingredientStore.GetAsync();
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                _ingredients = _ingredients.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery));
            }
            Ingredients.Clear();
            foreach (var ingredient in _ingredients)
                Ingredients.Add(ingredient);
        }
    }
}
