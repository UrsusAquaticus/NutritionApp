using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class SittingMeal : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Sitting))]
        public int SittingId { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        //Private
        private Meal meal;
        private float numberOfServings;

        //Public
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Meal Meal { get => meal; set => SetValue(ref meal, value); }
        public float NumberOfServings { get => numberOfServings; set => SetValue(ref numberOfServings, value); }
    }
}
