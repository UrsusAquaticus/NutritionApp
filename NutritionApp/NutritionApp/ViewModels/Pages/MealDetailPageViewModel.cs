using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels.Tables;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class MealDetailPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Meal> _mealStore;
        private readonly IPageService _pageService;
        public Meal Meal { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public MealDetailPageViewModel(MealVM viewModel, IDataStore<Meal> mealStore, IPageService pageService)
        {
            _mealStore = mealStore;
            _pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Meal = new Meal
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ServingSizeGrams = viewModel.ServingSizeGrams
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Meal.Name))
            {
                await _pageService.DisplayAlert("Error", "Please enter meal name.", "OK");
                return;
            }
            if (Meal.Id == 0)
            {
                await _mealStore.AddAsync(Meal);
                MessagingCenter.Send(this, Events.MealAdded, Meal);
            }
            else
            {
                await _mealStore.UpdateAsync(Meal);
                MessagingCenter.Send(this, Events.MealUpdated, Meal);
            }
            await _pageService.PopAsync();
        }
    }
}
