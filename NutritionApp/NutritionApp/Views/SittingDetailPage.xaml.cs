using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class SittingDetailPage : ContentPage
    {
        public SittingDetailPage(Sitting sitting)
        {
            InitializeComponent();
            var pageService = new PageService();
            Title = (sitting.Id == 0) ? "New Sitting" : "Edit Sitting";
            BindingContext = new SittingDetailPageViewModel(sitting ?? new Sitting(), pageService);
        }

        // set ViewModel
        public SittingDetailPageViewModel ViewModel
        {
            get { return BindingContext as SittingDetailPageViewModel; }
            set { BindingContext = value; }
        }
    }
}