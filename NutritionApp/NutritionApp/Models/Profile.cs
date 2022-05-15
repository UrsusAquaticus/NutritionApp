using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace NutritionApp.Models
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        //
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Activity { get; set; }
        public bool Pregnant { get; set; }
    }
}