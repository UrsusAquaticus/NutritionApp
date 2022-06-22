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
    public partial class SittingMealsPage : ContentPage
    {

        public SittingMealsPage(Sitting sitting)
        {
            var pageService = new PageService();
            ViewModel = new SittingMealsViewModel(sitting, pageService);
            InitializeComponent();
        }

        public SittingMealsViewModel ViewModel
        {
            get { return BindingContext as SittingMealsViewModel; }
            set { BindingContext = value; }
        }

        void OnSittingMealSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

    }
}