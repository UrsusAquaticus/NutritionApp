using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.ObjectModel;

namespace NutritionApp.Models
{
    public class Sitting : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Profile))]
        public int ProfileId { get; set; }

        //Private
        private ObservableCollection<SittingMeal> sittingMeals;
        private DateTime date;
        private TimeSpan time;

        //Public
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<SittingMeal> SittingMeals
        {
            get
            {
                if (sittingMeals == null)
                {
                    sittingMeals = new ObservableCollection<SittingMeal>();
                }
                return sittingMeals;
            }
            set => SetValue(ref sittingMeals, value);
        }
        public DateTime Date { get => date; set => SetValue(ref date, value); }
        public TimeSpan Time { get => time; set => SetValue(ref time, value); }

        public void AddMeal(Tuple<Meal, float> meal)
        {
            SittingMeal sittingMeal = new SittingMeal
            {
                Meal = meal.Item1,
                NumberOfServings = meal.Item2
            };
            SittingMeals.Add(sittingMeal);
        }
    }

}
