using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NutritionApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NutritionApp.ViewModels;
using NutritionApp.Persistence;

namespace NutritionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsPage : ContentPage
    {
        public IngredientsPage()
        {
            var ingredientStore = new SQLiteIngredientStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new IngredientsPageViewModel(ingredientStore, pageService);
            InitializeComponent();     
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        void OnIngredientSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectIngredientCommand.Execute(e.SelectedItem);
        }

        // set ViewModel
        public IngredientsPageViewModel ViewModel
        {
            get { return BindingContext as IngredientsPageViewModel; }
            set { BindingContext = value;  }
        }



        //ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        //public ObservableCollection<Ingredient> Ingredients { get { return ingredients; } }

        //private void CreateIngredientList()
        //{
        //    ingredientList.ItemsSource = ingredients;

        //    ingredients.Add(new Ingredient { Name = "Apple", Kj = 30 });
        //    ingredients.Add(new Ingredient { Name = "Banana", Kj = 50 });
        //    ingredients.Add(new Ingredient { Name = "Pear", Kj = 30 });
        //    ingredients.Add(new Ingredient { Name = "Orange", Kj = 30});


        //}

        //private async void New_Ingredient_Clicked(object sender, EventArgs e)
        //{
        //    // register route
        //    Routing.RegisterRoute("NewIngredientPage", typeof(NewIngredientPage));

        //    await Shell.Current.GoToAsync("NewIngredientPage");

        //}


    }
}