using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class SittingsPage : ContentPage
    {
        public SittingsPage(Profile profile)
        {
            InitializeComponent();
            var pageService = new PageService();
            Title = profile.Name;
            BindingContext = new SittingsPageViewModel(profile, pageService);
        }

        void OnSittingSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectSittingCommand.Execute(e.SelectedItem);
        }

        // error says method with correct signature not found
        //void OnSittingDeleted(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ViewModel.DeleteSittingCommand.Execute(e.SelectedItem);
        //}

        public SittingsPageViewModel ViewModel
        {
            get { return BindingContext as SittingsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}