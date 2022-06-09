using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionApp.ViewModels.Tables
{
    public class MealVM : BaseViewModel
    {
        //private static IDataStore<Meal> dataStore;
        //private int id;
        //private string name;
        //private float servingSizeGrams;
        //private ObservableCollection<MealIngredientVM> mealIngredients;

        //public MealVM()
        //{
        //    dataStore = dataStore ?? SQLiteMealStore.GetInstance();
        //}

        //public MealVM(Meal meal)
        //{
        //    dataStore = dataStore ?? SQLiteMealStore.GetInstance();

        //    this.Id = meal.Id;
        //    this.Name = meal.Name;
        //    this.ServingSizeGrams = meal.ServingSizeGrams;

        //    ObservableCollection<MealIngredientVM> _tempMealIngredients = new ObservableCollection<MealIngredientVM>();
        //    foreach (var mealIngredient in meal.MealIngredients)
        //        _tempMealIngredients.Add(new MealIngredientVM(mealIngredient));
        //    this.MealIngredients = _tempMealIngredients;
        //}

        //public int Id { get => id; set => id = value; }

        //public string Name { get => name; set => SetValue(ref name, value); }
        //public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }
        //public ObservableCollection<MealIngredientVM> MealIngredients { get => mealIngredients ?? new ObservableCollection<MealIngredientVM>(); set => SetValue(ref mealIngredients, value); }

        //public async Task AddAsync()
        //{
        //    List<MealIngredient> mealIngredients = new List<MealIngredient>();
        //    foreach (MealIngredientVM mealIngredient in this.MealIngredients)
        //    {
        //        mealIngredients.Add(new MealIngredient
        //        {
        //            Id = mealIngredient.Id,
        //            NumberOfServings = mealIngredient.NumberOfServings,
        //            Ingredient = new Ingredient
        //            {
        //                Id = mealIngredient.Ingredient.Id,
        //                Name = mealIngredient.Ingredient.Name,
        //                ServingSizeGrams = mealIngredient.Ingredient.ServingSizeGrams,
        //                Kj = mealIngredient.Ingredient.Kj
        //            }
        //        });
        //    }

        //    Meal meal = new Meal
        //    {
        //        Id = this.Id,
        //        Name = this.Name,
        //        ServingSizeGrams = this.ServingSizeGrams,
        //        MealIngredients = mealIngredients
        //    };

        //    await dataStore.AddWithChildrenAsync(meal);
        //}
        //public Task UpdateAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
