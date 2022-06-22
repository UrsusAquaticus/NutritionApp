using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class SittingMealsViewModel : BaseViewModel
    {
        private readonly IDataStore<SittingMeal> sittingMealStore;
        private readonly IPageService pageService;
        private bool isDataLoaded;
        public Sitting Sitting { get; private set; }
        
        public SittingMealsViewModel(Sitting sitting, IPageService pageService)
        {
            Sitting = sitting;
            this.pageService = pageService;
            sittingMealStore = App.Database.SittingMealStore;

            foreach (var sittingMeal in sitting.SittingMeals)
                SittingMeals.Add(sittingMeal);
        }

        private ObservableCollection<SittingMeal> sittingMeals = new ObservableCollection<SittingMeal>();
        public ObservableCollection<SittingMeal> SittingMeals
        {
            get
            {
                return sittingMeals;
            }
            set
            {
                SetValue(ref sittingMeals, value);
            }
        }

    }
}
