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
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            var db = DependencyService.Get<ISQLiteDb>();
            SQLiteIngredientStore.Instantiate(db);
            SQLiteMealIngredientStore.Instantiate(db);
            SQLiteMealStore.Instantiate(db);
            SQLiteProfileMealStore.Instantiate(db);
            SQLiteProfileStore.Instantiate(db);
            SQLiteGoalStore.Instantiate(db);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
