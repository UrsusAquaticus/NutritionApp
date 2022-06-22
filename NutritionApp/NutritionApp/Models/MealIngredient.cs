using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class MealIngredient : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        [ForeignKey(typeof(Ingredient))]
        public int IngredientId { get; set; }

        //Private
        private Ingredient ingredient;
        private float numberOfServings;
        private float kj;

        //Public
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Ingredient Ingredient { get => ingredient; set { SetValue(ref ingredient, value); TotalKj(); } }
        public float NumberOfServings { get => numberOfServings; set { SetValue(ref numberOfServings, value); TotalKj(); } }
        public float Kj { get => kj; }

        private void TotalKj()
        {
            if (Ingredient == null) return;
            var n = Ingredient.Kj / Ingredient.ServingSizeGrams * NumberOfServings;
            SetValue(ref kj, n);
        }
    }
}
