using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.ViewModels.Tables
{
    public class MealIngredientVM : BaseViewModel
    {
        private int id;
        private int mealId;
        private int ingredientId;
        private float numberOfServings;
        private IngredientVM ingredient;

        public MealIngredientVM()
        {
        }
        public MealIngredientVM(MealIngredient mealIngredient)
        {
            this.Id = mealIngredient.Id;
            this.MealId = mealIngredient.MealId;
            this.IngredientId = mealIngredient.IngredientId;
            this.NumberOfServings = mealIngredient.NumberOfServings;
            this.Ingredient = new IngredientVM(mealIngredient.Ingredient);
        }

        public int Id { get => id; set => id = value; }
        public int MealId { get => mealId; set => SetValue(ref mealId, value); }
        public int IngredientId { get => ingredientId; set => SetValue(ref ingredientId, value); }
        public float NumberOfServings { get => numberOfServings; set => SetValue(ref numberOfServings, value); }
        public IngredientVM Ingredient { get => ingredient; set => SetValue(ref ingredient, value); }
    }
}
