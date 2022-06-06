using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using NutritionApp.ViewModels.Tables;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class MealDetailPage : ContentPage
    {
        public MealDetailPage(MealVM viewModel)
        {
            InitializeComponent();
            var pageService = new PageService();
            Title = (viewModel.Id == 0) ? "New Meal" : "Edit Meal";
            BindingContext = new MealDetailPageViewModel(viewModel ?? new MealVM(), pageService);
        }

        // set ViewModel
        public MealDetailPageViewModel ViewModel
        {
            get { return BindingContext as MealDetailPageViewModel; }
            set { BindingContext = value; }
        }
    }
}