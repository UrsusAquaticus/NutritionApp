using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class ProfileMeal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Profile))]
        public int ProfileId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Profile Profile { get; set; }

        [ForeignKey(typeof(Meal))]
        public int MealId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Meal Meal { get; set; }

        //
        public DateTime Time { get; set; }
        public float NumberOfServings { get; set; }
    }
}
