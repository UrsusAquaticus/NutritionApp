using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class MealDetailPage : ContentPage
    {
        public MealDetailPage(Meal meal)
        {
            InitializeComponent();
            var pageService = new PageService();
            Title = (meal.Id == 0) ? "New Meal" : "Edit Meal";
            BindingContext = new MealDetailPageViewModel(meal ?? new Meal(), pageService);
        }

        // set ViewModel
        public MealDetailPageViewModel ViewModel
        {
            get { return BindingContext as MealDetailPageViewModel; }
            set { BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
    }
}