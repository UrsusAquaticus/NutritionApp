using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class MealIngredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        [ForeignKey(typeof(Ingredient))]
        public int IngredientId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Ingredient Ingredient { get; set; }

        //
        public float numberOfServings { get; set; }
    }
}
