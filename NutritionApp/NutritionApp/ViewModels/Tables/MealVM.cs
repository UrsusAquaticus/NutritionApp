using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NutritionApp.ViewModels.Tables
{
    public class MealVM : BaseViewModel
    {
        private int id;
        private string name;
        private float servingSizeGrams;
        private ObservableCollection<MealIngredientVM> mealIngredients;

        public MealVM()
        {
        }

        public MealVM(Meal meal)
        {
            this.Id = meal.Id;
            this.Name = meal.Name;
            this.ServingSizeGrams = meal.ServingSizeGrams;

            ObservableCollection<MealIngredientVM> _tempMealIngredient = new ObservableCollection<MealIngredientVM>();
            foreach (var mealIngredient in meal.MealIngredient)
                _tempMealIngredient.Add(new MealIngredientVM(mealIngredient));
            this.MealIngredients = _tempMealIngredient;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => SetValue(ref name, value); }
        public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }
        public ObservableCollection<MealIngredientVM> MealIngredients { get => mealIngredients; set => SetValue(ref mealIngredients, value); }
    }
}
