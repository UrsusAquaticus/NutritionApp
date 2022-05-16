using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class Meal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<MealIngredient> MealIngredient { get; set; }

        //
        public string Name { get; set; }
        public float ServingSizeGrams { get; set; }
    }

}
