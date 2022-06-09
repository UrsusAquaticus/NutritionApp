using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace NutritionApp.Models
{
    public class Profile : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Private
        private string name;
        private DateTime dOB;
        private string gender;
        private float weight;
        private float height;
        private float activity;
        private bool pregnant;

        //Public
        public string Name { get => name; set => SetValue(ref name, value); }
        public DateTime DOB { get => dOB; set => SetValue(ref dOB, value); }
        public string Gender { get => gender; set => SetValue(ref gender, value); }
        public float Weight { get => weight; set => SetValue(ref weight, value); }
        public float Height { get => height; set => SetValue(ref height, value); }
        public float Activity { get => activity; set => SetValue(ref activity, value); }
        public bool Pregnant { get => pregnant; set => SetValue(ref pregnant, value); }

    }
}