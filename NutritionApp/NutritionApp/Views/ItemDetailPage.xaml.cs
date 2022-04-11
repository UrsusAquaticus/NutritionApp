using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}