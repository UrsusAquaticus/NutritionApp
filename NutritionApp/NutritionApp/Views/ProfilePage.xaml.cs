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
using System.Collections.ObjectModel;

namespace NutritionApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel _viewModel;

        public ProfilePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ProfileViewModel();
            CreateProfileList();
        }

        ObservableCollection<Profile> profiles = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> Profiles { get { return profiles; } }

        private void CreateProfileList()
        {
            profileList.ItemsSource = profiles;
            profiles.Add(new Profile { Name = "Dani JS" });
            profiles.Add(new Profile { Name = "Zach" });
            profiles.Add(new Profile { Name = "Sam" });
            profiles.Add(new Profile { Name = "Jethro" });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnAppearing();
        }

        private async void New_Profile_Clicked(object sender, EventArgs e)
        {
            // register route
            Routing.RegisterRoute("NewProfilePage", typeof(NewProfilePage));

            await Shell.Current.GoToAsync("NewProfilePage");

        }
    }
}