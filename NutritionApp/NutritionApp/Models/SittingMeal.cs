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
        private Sitting sitting;
        private Meal meal;
        private float numberOfServings;
        private float kj;

        //Public
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Sitting Sitting { get => sitting; set { SetValue(ref sitting, value); TotalKj(); } }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Meal Meal { get => meal; set { SetValue(ref meal, value); TotalKj(); } }
        public float NumberOfServings { get => numberOfServings; set { SetValue(ref numberOfServings, value); TotalKj(); } }
        public float Kj { get => kj; }

        private void TotalKj()
        {
            if (Meal == null) return;
            var n = Meal.Kj / Meal.ServingSizeGrams * NumberOfServings;
            SetValue(ref kj, n);
        }
    }
}
