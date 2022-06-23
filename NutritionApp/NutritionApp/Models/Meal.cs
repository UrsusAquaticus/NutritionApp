using NutritionApp.ViewModels;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.ObjectModel;

namespace NutritionApp.Models
{
    public class Meal : BaseViewModel
    {
        //IDs
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Private
        private ObservableCollection<MealIngredient> mealIngredients;
        private string name;
        private float servingSizeGrams;
        private float kj;

        //Public
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<MealIngredient> MealIngredients
        {
            get
            {
                if (mealIngredients == null)
                {
                    mealIngredients = new ObservableCollection<MealIngredient>();
                }
                return mealIngredients;
            }
            set
            {
                SetValue(ref mealIngredients, value);
                TotalKj();
            }
        }
        public string Name { get => name; set => SetValue(ref name, value);  }
        public float ServingSizeGrams { get => servingSizeGrams; set {  SetValue(ref servingSizeGrams, value); TotalKj(); } }
        public float Kj { get => kj; private set => SetValue(ref kj, value); }

        public void AddIngredient(Tuple<Ingredient, float> ingredient)
        {
            MealIngredient mealIngredient = new MealIngredient
            {
                Ingredient = ingredient.Item1,
                NumberOfServings = ingredient.Item2
            };
            MealIngredients.Add(mealIngredient);
        }

        private void TotalKj()
        {
            if (MealIngredients == null) return;
            float total = 0f;
            foreach(var mealIngredient in MealIngredients)
            {
                total += mealIngredient.Kj;
            }
            Kj = total;
        }
    }

}
