using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NutritionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;

namespace NutritionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealsPage : ContentPage
    {
        public MealsPage()
        {
            var pageService = new PageService();
            ViewModel = new MealsPageViewModel(pageService);
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        void OnMealSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectMealCommand.Execute(e.SelectedItem);
        }


        // set ViewModel
        public MealsPageViewModel ViewModel
        {
            get { return BindingContext as MealsPageViewModel; }
            set { BindingContext = value; }
        }
    }
}