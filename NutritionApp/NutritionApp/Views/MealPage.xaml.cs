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
    public partial class MealPage : ContentPage
    {
        public MealPage()
        {
            InitializeComponent();
        }

        private async void New_Meal_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewMealPage", typeof(NewMealPage));

            await Shell.Current.GoToAsync("NewMealPage");

        }
    }
}