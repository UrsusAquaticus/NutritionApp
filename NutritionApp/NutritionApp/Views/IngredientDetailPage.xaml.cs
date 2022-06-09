using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class IngredientDetailPage : ContentPage
    {
        public IngredientDetailPage(Ingredient ingredient)
        {
            InitializeComponent();

            var pageService = new PageService();
            Title = (ingredient.Id == 0) ? "New Ingredient" : "Edit Ingredient";
            BindingContext = new IngredientDetailPageViewModel(ingredient ?? new Ingredient(), pageService);
        }
    }
}