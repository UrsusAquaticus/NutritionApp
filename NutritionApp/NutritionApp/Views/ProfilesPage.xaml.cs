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
using NutritionApp.Persistence;

namespace NutritionApp.Views
{
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage()
        {
            var profileStore = new SQLiteProfileStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ProfilesPageViewModel(profileStore, pageService);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        void OnProfileSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectProfileCommand.Execute(e.SelectedItem);
        }
        public ProfilesPageViewModel ViewModel
        {
            get { return BindingContext as ProfilesPageViewModel; }
            set { BindingContext = value; }
        }

    }
}