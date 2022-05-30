using NutritionApp.Models;
using System;

namespace NutritionApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private int id;
        private string name;
        private DateTime dOB;
        private string gender;
        private float weight;
        private float height;
        private float activity;
        private bool pregnant;

        public ProfileViewModel()
        {
        }

        public ProfileViewModel(Profile profile)
        {
            this.id = profile.Id;
            this.name = profile.Name;
            this.dOB = profile.DOB;
            this.gender = profile.Gender;
            this.weight = profile.Weight;
            this.height = profile.Height;
            this.activity = profile.Activity;
            this.pregnant = profile.Pregnant;
        }

        public int Id { get => id; }
        public string Name { get => name; set => SetValue(ref name, value); }
        public DateTime DOB { get => dOB; set => SetValue(ref dOB, value); }
        public string Gender { get => gender; set => SetValue(ref gender, value); }
        public float Weight { get => weight; set => SetValue(ref weight, value); }
        public float Height { get => height; set => SetValue(ref height, value); }
        public float Activity { get => activity; set => SetValue(ref activity, value); }
        public bool Pregnant { get => pregnant; set => SetValue(ref pregnant, value); }
    }
}
