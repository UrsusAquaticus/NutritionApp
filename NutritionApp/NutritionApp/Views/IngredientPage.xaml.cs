using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private async void New_Ingredient_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewIngredientPage", typeof(NewIngredientPage));

            await Shell.Current.GoToAsync("NewIngredientPage");

        }
    }
}