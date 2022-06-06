using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class IngredientVM : BaseViewModel
    {
        private static IDataStore<Ingredient> dataStore;
        private int id;
        private string name;
        private float servingSizeGrams;
        private float kj;

        public IngredientVM()
        {
        }

        public IngredientVM(Ingredient ingredient)
        {
            DataStore = DataStore ?? new SQLiteIngredientStore(DependencyService.Get<ISQLiteDb>());

            this.id = ingredient.Id;
            this.name = ingredient.Name;
            this.servingSizeGrams = ingredient.ServingSizeGrams;
            this.kj = ingredient.Kj;
        }

        public static IDataStore<Ingredient> DataStore { get => dataStore ?? new SQLiteIngredientStore(DependencyService.Get<ISQLiteDb>()); set => dataStore = value; }
        public int Id { get => id; }
        public string Name { get => name; set => SetValue(ref name, value); }
        public float ServingSizeGrams { get => servingSizeGrams; set => SetValue(ref servingSizeGrams, value); }
        public float Kj { get => kj; set => SetValue(ref kj, value); }
    }
}
