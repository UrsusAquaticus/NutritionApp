using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp
{
    public partial class App : Application
    {

        public App()
        {
            var database = DependencyService.Get<ISQLiteDb>();

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
