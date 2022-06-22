using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class SittingDetailsViewPage : ContentPage
    {
        public SittingDetailsViewPage(Sitting sitting)
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

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
    }
}