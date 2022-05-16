using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NutritionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientPage : ContentPage
    {
        public IngredientPage()
        {
            InitializeComponent();
            CreateIngredientList();
        }

        ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public ObservableCollection<Ingredient> Ingredients { get { return ingredients; } }

        private void CreateIngredientList()
        {
            ingredientList.ItemsSource = ingredients;

            ingredients.Add(new Ingredient { Name = "Apple", kj = 30 });
            ingredients.Add(new Ingredient { Name = "Banana", kj = 50 });
            ingredients.Add(new Ingredient { Name = "Pear", kj = 30 });
            ingredients.Add(new Ingredient { Name = "Orange", kj = 30});


        }

        private async void New_Ingredient_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewIngredientPage", typeof(NewIngredientPage));

            await Shell.Current.GoToAsync("NewIngredientPage");

        }


    }
}