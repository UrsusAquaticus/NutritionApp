using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class MealDetailPageViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        public MealVM Meal { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public MealDetailPageViewModel(MealVM viewModel, IPageService pageService)
        {
            _pageService = pageService;

            Meal = viewModel;
            new Command(async () => { await GetIngredients(); }).Execute(null);

            SaveCommand = new Command(async () => await Save());
        }

        private async Task GetIngredients()
        {
            var mealIngredientsVM = new ObservableCollection<MealIngredientVM>();
            int i = 0;
            foreach (var ingredient in await IngredientVM.DataStore.GetAsync())
            {
                mealIngredientsVM.Add(new MealIngredientVM
                {
                    Id = 0,
                    NumberOfServings = i++,
                    Ingredient = new IngredientVM(ingredient)
                });
            }

            Meal.MealIngredients = mealIngredientsVM;
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
                await Meal.AddAsync();
                MessagingCenter.Send(this, Events.MealAdded, Meal);
            }
            else
            {
                await Meal.UpdateAsync();
                MessagingCenter.Send(this, Events.MealUpdated, Meal);
            }
            await _pageService.PopAsync();
        }
    }
}
