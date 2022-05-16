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
    public partial class MealPage : ContentPage
    {
        public MealPage()
        {
            InitializeComponent();
            CreateMealList();
        }

        ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        public ObservableCollection<Meal> Meals { get { return meals; } }

        private void CreateMealList()
        {
            mealList.ItemsSource = meals;

            meals.Add(new Meal { Name = "Apple Pie"});
            meals.Add(new Meal { Name = "Banana Split"});
            meals.Add(new Meal { Name = "Pear Tart"});
            meals.Add(new Meal { Name = "Orange Juice"});


        }

        private async void New_Meal_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewMealPage", typeof(NewMealPage));

            await Shell.Current.GoToAsync("NewMealPage");

        }
    }
}