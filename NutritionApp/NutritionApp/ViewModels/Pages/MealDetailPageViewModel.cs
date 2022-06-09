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
    public class MealDetailPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Meal> mealStore;
        private readonly IDataStore<Ingredient> ingredientStore;
        //private readonly IDataStore<MealIngredient> mealIngredientStore;
        private readonly IPageService pageService;
        public Meal Meal { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public MealDetailPageViewModel(Meal meal, IPageService pageService)
        {
            Meal = meal;
            this.pageService = pageService;

            mealStore = App.Database.MealStore;
            ingredientStore = App.Database.IngredientStore;
            //mealIngredientStore = App.Database.MealIngredientStore;

            new Command(async () => { await GetIngredients(); }).Execute(null);

            SaveCommand = new Command(async () => await Save());
        }

        private async Task GetIngredients()
        {
            var mealIngredients = new List<MealIngredient>();
            int i = 0;
            foreach (var ingredient in await ingredientStore.GetAsync())
            {
                mealIngredients.Add(new MealIngredient
                {
                    Id = 0,
                    NumberOfServings = i++,
                    Ingredient = ingredient
                });
            }

            Meal.MealIngredients = mealIngredients;
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Meal.Name))
            {
                await pageService.DisplayAlert("Error", "Please enter meal name.", "OK");
                return;
            }
            if (Meal.Id == 0)
            {
                await mealStore.AddWithChildrenAsync(Meal);
                MessagingCenter.Send(this, Events.MealAdded, Meal);
            }
            else
            {
                await mealStore.UpdateAsync(Meal);
                MessagingCenter.Send(this, Events.MealUpdated, Meal);
            }
            await pageService.PopAsync();
        }
    }
}
