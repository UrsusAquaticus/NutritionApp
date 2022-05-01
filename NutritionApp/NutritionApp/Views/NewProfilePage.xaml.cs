using NutritionApp.Models;
using NutritionApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp.Views
{
    public partial class NewProfilePage : ContentPage
    {
        public Item Item { get; set; }

        public NewProfilePage()
        {
            InitializeComponent();
            BindingContext = new NewFoodViewModel();
        }
    }
}