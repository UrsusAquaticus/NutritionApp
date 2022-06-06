using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels.Tables;
using NutritionApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class MealsPageViewModel : BaseViewModel
    {
        //https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
        //Look here for how to implement the custom interface 'IPageService'
        private MealVM _selectedMeal;
        private IDataStore<Meal> _mealStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        private ObservableCollection<MealVM> _meals { get; set; } = new ObservableCollection<MealVM>();
        public ObservableCollection<MealVM> Meals
        {
            get
            {
                return _meals;
            }
            set
            {
                _meals = value;
                OnPropertyChanged();
            }
        }

        public MealVM SelectedMeal
        {
            get { return _selectedMeal; }
            set { SetValue(ref _selectedMeal, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddMealCommand { get; private set; }
        public ICommand SelectMealCommand { get; private set; }
        public ICommand DeleteMealCommand { get; private set; }
        public ICommand FilterMealCommand { get; private set; }

        public MealsPageViewModel(IDataStore<Meal> mealStore, IPageService pageService)
        {
            _mealStore = mealStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddMealCommand = new Command(async () => await AddMeal());
            SelectMealCommand = new Command<MealVM>(async c => await SelectMeal(c));
            DeleteMealCommand = new Command<MealVM>(async c => await DeleteMeal(c));
            FilterMealCommand = new Command<string>(async c => await FilterMeal(c));

            MessagingCenter.Subscribe<MealDetailPageViewModel, Meal>(this, Events.MealAdded, OnMealAdded);
            MessagingCenter.Subscribe<MealDetailPageViewModel, Meal>(this, Events.MealUpdated, OnMealUpdated);
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            var meals = await _mealStore.GetAsync();
            foreach (var meal in meals)
                Meals.Add(new MealVM(meal));
        }
        private void OnMealAdded(MealDetailPageViewModel source, Meal meal)
        {
            Meals.Add(new MealVM(meal));
        }
        private void OnMealUpdated(MealDetailPageViewModel source, Meal meal)
        {
            var mealInList = Meals.Single(c => c.Id == meal.Id);
            mealInList.Name = meal.Name;
            mealInList.ServingSizeGrams = meal.ServingSizeGrams;
        }

        private async Task AddMeal()
        {
            await _pageService.PushAsync(new MealDetailPage(new MealVM()));
        }

        private async Task SelectMeal(MealVM meal)
        {
            if (meal == null)
                return;
            SelectedMeal = null;
            await _pageService.PushAsync(new MealDetailPage(meal));

        }

        private async Task DeleteMeal(MealVM mealVM)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {mealVM.Name}?", "Yes", "No"))
            {
                Meals.Remove(mealVM);
                var meal = await _mealStore.GetAsync(mealVM.Id);
                await _mealStore.DeleteAsync(meal.Id);
            }
        }

        // perform search using a viewmodel... https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar#perform-a-search-using-a-viewmodel
        public async Task FilterMeal(string queryString)
        {
            // check if queryString is null, if not put to lower, if null return empty string
            var normalizedQuery = queryString?.ToLower() ?? "";
            var meals = await _mealStore.GetAsync();
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                meals = meals.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery));
            }
            Meals.Clear();
            foreach (var meal in meals)
                Meals.Add(new MealVM(meal));
        }

    }
}
