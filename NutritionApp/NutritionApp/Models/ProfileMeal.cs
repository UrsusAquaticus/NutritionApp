using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class ProfileMeal : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Profile))]
        public int ProfileId { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        //Private
        private Profile profile;
        private Meal meal;
        private DateTime time;
        private float numberOfServings;

        //Public
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Profile Profile { get => profile; set => SetValue(ref profile, value); }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Meal Meal { get => meal; set => SetValue(ref meal, value); }
        public DateTime Time { get => time; set => SetValue(ref time, value); }
        public float NumberOfServings { get => numberOfServings; set => SetValue(ref numberOfServings, value); }
    }
}
