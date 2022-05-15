using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Models
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Name { get; set; }
        public float ServingSizeGrams { get; set; }
        public float kj { get; set; }//kj per serving size
    }

}
