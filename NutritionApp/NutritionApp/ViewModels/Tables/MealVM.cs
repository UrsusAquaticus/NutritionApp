using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NutritionApp.ViewModels.Tables
{
    class MealVM : BaseViewModel
    {
        private int id;
        private string name;
        private float servingSizeGrams;
        private ObservableCollection<MealIngredientVM> mealIngredients;

        public MealVM()
        {
        }

        public MealVM(int id, string name, float servingSizeGrams, ObservableCollection<MealIngredientVM> mealIngredients)
        {
            this.Id = id;
            this.Name = name;
            this.ServingSizeGrams = servingSizeGrams;
            this.MealIngredients = mealIngredients;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => SetValue(ref name, value); }
        public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }
        public ObservableCollection<MealIngredientVM> MealIngredients { get => mealIngredients; set => SetValue(ref mealIngredients, value); }
    }
}
