using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NutritionApp.Models
{
    public class Profile : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Private
        private ObservableCollection<Sitting> sittings;
        private string name;
        private DateTime dOB;
        private string gender;
        private float weight;
        private float height;
        private float activity;
        private bool pregnant;

        //Public
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Sitting> Sittings
        {
            get
            {
                if (sittings == null)
                {
                    sittings = new ObservableCollection<Sitting>();
                }
                return sittings;
            }
            set => SetValue(ref sittings, value);
        }
        public string Name { get => name; set => SetValue(ref name, value); }
        public DateTime DOB { get => dOB; set => SetValue(ref dOB, value); }
        public string Gender { get => gender; set => SetValue(ref gender, value); }
        public float Weight { get => weight; set => SetValue(ref weight, value); }
        public float Height { get => height; set => SetValue(ref height, value); }
        public float Activity { get => activity; set => SetValue(ref activity, value); }
        public bool Pregnant { get => pregnant; set => SetValue(ref pregnant, value); }
    }
}