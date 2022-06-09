using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
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
        private Meal selectedMeal;
        private readonly IDataStore<Meal> mealStore;
        //private readonly IDataStore<MealIngredient> mealIngredientStore;
        private readonly IPageService pageService;

        private bool _isDataLoaded;

        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        public ObservableCollection<Meal> Meals
        {
            get
            {
                return meals;
            }
            set
            {
                SetValue(ref meals, value);
            }
        }

        public Meal SelectedMeal
        {
            get { return selectedMeal; }
            set { SetValue(ref selectedMeal, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddMealCommand { get; private set; }
        public ICommand SelectMealCommand { get; private set; }
        public ICommand DeleteMealCommand { get; private set; }
        public ICommand FilterMealCommand { get; private set; }

        public MealsPageViewModel(IPageService pageService)
        {
            this.pageService = pageService;

            mealStore = App.Database.MealStore;
            //mealIngredientStore = App.Database.MealIngredientStore;

            LoadDataCommand = new Command(async () => await LoadData());
            AddMealCommand = new Command(async () => await AddMeal());
            SelectMealCommand = new Command<Meal>(async c => await SelectMeal(c));
            DeleteMealCommand = new Command<Meal>(async c => await DeleteMeal(c));
            FilterMealCommand = new Command<string>(async c => await FilterMeal(c));

            MessagingCenter.Subscribe<MealDetailPageViewModel, Meal>(this, Events.MealAdded, OnMealAdded);
            MessagingCenter.Subscribe<MealDetailPageViewModel, Meal>(this, Events.MealUpdated, OnMealUpdated);
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            var meals = await mealStore.GetAsync();
            foreach (var meal in meals)
                Meals.Add(meal);
        }
        private void OnMealAdded(MealDetailPageViewModel source, Meal meal)
        {
            Meals.Add(meal);
        }
        private void OnMealUpdated(MealDetailPageViewModel source, Meal meal)
        {
            var mealInList = Meals.Single(c => c.Id == meal.Id);
            mealInList = meal;
        }

        private async Task AddMeal()
        {
            await pageService.PushAsync(new MealDetailPage(new Meal()));
        }

        private async Task SelectMeal(Meal meal)
        {
            if (meal == null)
                return;
            SelectedMeal = null;
            var expandedMeal = await mealStore.GetWithChildrenAsync(meal.Id);
            await pageService.PushAsync(new MealDetailPage(expandedMeal));
        }

        private async Task DeleteMeal(Meal meal)
        {
            if (await pageService.DisplayAlert("Warning", $"Are you sure you want to delete {meal.Name}?", "Yes", "No"))
            {
                Meals.Remove(meal);
                await mealStore.DeleteAsync(meal.Id);
            }
        }

        // perform search using a viewmodel... https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar#perform-a-search-using-a-viewmodel
        public async Task FilterMeal(string queryString)
        {
            // check if queryString is null, if not put to lower, if null return empty string
            var normalizedQuery = queryString?.ToLower() ?? "";
            var _meals = await mealStore.GetAsync();
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                _meals = _meals.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery));
            }
            Meals.Clear();
            foreach (var meal in _meals)
                Meals.Add(meal);
        }

    }
}
