using NutritionApp.Models;
using NutritionApp.ViewModels;
using NutritionApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel _viewModel;

        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ProfileViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void New_Profile_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewProfilePage", typeof(NewProfilePage));

            await Shell.Current.GoToAsync("NewProfilePage");

        }
    }
}