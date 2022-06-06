using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class IngredientDetailPage : ContentPage
    {
        public IngredientDetailPage(IngredientVM viewModel)
        {
            InitializeComponent();

            var ingredientStore = SQLiteIngredientStore.GetInstance();
            var pageService = new PageService();
            Title = (viewModel.Id == 0) ? "New Ingredient" : "Edit Ingredient";
            BindingContext = new IngredientDetailPageViewModel(viewModel ?? new IngredientVM(), ingredientStore, pageService);
        }
    }
}