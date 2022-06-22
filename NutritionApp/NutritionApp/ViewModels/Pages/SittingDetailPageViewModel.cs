using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class SittingDetailPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Sitting> sittingStore;
        private readonly IDataStore<Meal> mealStore;

        private readonly IPageService pageService;
        private bool isDataLoaded;
        public Sitting Sitting { get; private set; }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand RandomMealCommand { get; private set; }

        // load meals collection for use in picker
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

        public SittingDetailPageViewModel(Sitting sitting, IPageService pageService)
        {
            Sitting = sitting;
            this.pageService = pageService;

            sittingStore = App.Database.SittingStore;
            mealStore = App.Database.MealStore;

            LoadDataCommand = new Command(async () => await LoadData());
            SaveCommand = new Command(async () => await Save());
            RandomMealCommand = new Command(async () => await RandomMeal());
        }


        /// <summary>
        /// Load Meal collection on load
        /// unsure what else needed
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            if (isDataLoaded)
                return;
            isDataLoaded = true;
            var meals = await mealStore.GetAsync();
            foreach (var meal in meals)
                Meals.Add(meal);
        }



        private async Task RandomMeal()
        {
            var meals = (List<Meal>)await mealStore.GetAsync();
            var rndNumber = new Random().Next(0, meals.Count);
            var meal = meals[rndNumber];
            Sitting.AddMeal(new Tuple<Meal, float>(meal, (float)rndNumber));
        }

        private async Task Save()
        {
            if (Sitting.SittingMeals.Count < 1)
            {
                await pageService.DisplayAlert("Error", "Please add a meal", "OK");
                return;
            }
            if (Sitting.Id == 0)
            {
                await sittingStore.AddWithChildrenAsync(Sitting);
                MessagingCenter.Send(this, Events.SittingAdded, Sitting);
            }
            else
            {
                await sittingStore.UpdateWithChildrenAsync(Sitting);
                MessagingCenter.Send(this, Events.SittingUpdated, Sitting);
            }
            await pageService.PopAsync();
        }
    }
}
