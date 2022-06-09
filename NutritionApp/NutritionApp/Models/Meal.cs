using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class Meal : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Private
        private List<MealIngredient> mealIngredients;
        private string name;
        private float servingSizeGrams;

        //Public
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<MealIngredient> MealIngredients { get => mealIngredients; set => SetValue(ref mealIngredients, value); }
        public string Name { get => name; set => SetValue(ref name, value); }
        public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }

    }

}
