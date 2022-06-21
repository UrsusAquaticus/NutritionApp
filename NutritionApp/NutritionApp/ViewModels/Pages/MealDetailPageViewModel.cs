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

        private readonly IPageService pageService;
        private bool isDataLoaded;
        public Meal Meal { get; private set; }
        
        public ICommand LoadDataCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand RandomIngredientCommand { get; private set; }

        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
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



        public MealDetailPageViewModel(Meal meal, IPageService pageService)
        {
            Meal = meal;
            this.pageService = pageService;

            mealStore = App.Database.MealStore;
            ingredientStore = App.Database.IngredientStore;

            LoadDataCommand = new Command(async () => await LoadData());
            SaveCommand = new Command(async () => await Save());
            RandomIngredientCommand = new Command(async () => await RandomIngredient());
        }

        /// <summary>
        /// Load Ingredient collection on load
        /// unsure what else needed
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            if (isDataLoaded)
                return;
            isDataLoaded = true;
            var ingredients = await ingredientStore.GetAsync();
            foreach (var ingredient in ingredients)
                Ingredients.Add(ingredient);
        }

        private async Task RandomIngredient()
        {
            var ingredients = (List<Ingredient>)await ingredientStore.GetAsync();
            var rndNumber = new Random().Next(0, ingredients.Count);
            var ingredient = ingredients[rndNumber];
            Meal.AddIngredient(new Tuple<Ingredient, float>(ingredient, (float)rndNumber));
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Meal.Name))
            {
                await pageService.DisplayAlert("Error", "Please enter meal name.", "OK");
                return;
            }
            if (Meal.MealIngredients.Count < 1)
            {
                await pageService.DisplayAlert("Error", "Please add an ingredient", "OK");
                return;
            }
            if (Meal.Id == 0)
            {
                await mealStore.AddWithChildrenAsync(Meal);
                MessagingCenter.Send(this, Events.MealAdded, Meal);
            }
            else
            {
                await mealStore.UpdateWithChildrenAsync(Meal);
                MessagingCenter.Send(this, Events.MealUpdated, Meal);
            }
            await pageService.PopAsync();
        }
    }
}
