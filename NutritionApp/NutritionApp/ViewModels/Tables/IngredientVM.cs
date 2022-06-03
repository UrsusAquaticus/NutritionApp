using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.ViewModels
{
    class IngredientVM : BaseViewModel
    {
        private int id;
        private string name;
        private float servingSizeGrams;
        private float kj;

        public IngredientVM()
        {
        }

        public IngredientVM(int id, string name, float servingSizeGrams, float kj)
        {
            this.id = id;
            this.name = name;
            this.servingSizeGrams = servingSizeGrams;
            this.kj = kj;
        }

        public int Id { get => id; }
        public string Name { get => name; set => SetValue(ref name, value); }
        public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }
        public float Kj { get => kj; set => SetValue(ref kj, value); }
    }
}
