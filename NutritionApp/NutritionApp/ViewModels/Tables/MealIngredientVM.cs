using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.ViewModels.Tables
{
    class MealIngredientVM : BaseViewModel
    {
        private int id;
        private int mealId;
        private int ingredientId;
        private float numberOfServings;
        private IngredientVM ingredient;

        public MealIngredientVM()
        {
        }
        public MealIngredientVM(int id, int mealId, int ingredientId, float numberOfServings, IngredientVM ingredient)
        {
            this.Id = id;
            this.MealId = mealId;
            this.IngredientId = ingredientId;
            this.NumberOfServings = numberOfServings;
            this.Ingredient = ingredient;
        }

        public int Id { get => id; set => id = value; }
        public int MealId { get => mealId; set => SetValue(ref mealId, value); }
        public int IngredientId { get => ingredientId; set => SetValue(ref ingredientId, value); }
        public float NumberOfServings { get => numberOfServings; set => SetValue(ref numberOfServings, value); }
        internal IngredientVM Ingredient { get => ingredient; set => SetValue(ref ingredient, value); }
    }
}
