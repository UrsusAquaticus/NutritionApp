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
        public Sitting Sitting { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand RandomMealCommand { get; private set; }
        public SittingDetailPageViewModel(Sitting sitting, IPageService pageService)
        {
            Sitting = sitting;
            this.pageService = pageService;

            sittingStore = App.Database.SittingStore;
            mealStore = App.Database.MealStore;

            SaveCommand = new Command(async () => await Save());
            RandomMealCommand = new Command(async () => await RandomMeal());
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
