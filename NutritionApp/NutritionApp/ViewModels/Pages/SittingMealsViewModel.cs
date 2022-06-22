using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class SittingMealsViewModel : BaseViewModel
    {
        //https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
        //Look here for how to implement the custom interface 'IPageService'
        private SittingMeal selectedSittingMeal;
        private readonly IDataStore<SittingMeal> _sittingMealStore;
        private readonly IPageService _pageService;
        public Sitting Sitting { get; private set; }

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


        public SittingMeal SelectedSittingMeal
        {
            get { return selectedSittingMeal; }
            set { SetValue(ref selectedSittingMeal, value); }
        }
        public ICommand SelectSittingMealCommand { get; private set; }

        public SittingMealsViewModel(Sitting sitting, IPageService pageService)
        {
            Sitting = sitting;
            this._pageService = pageService;

            _sittingMealStore = App.Database.SittingMealStore;

            SelectSittingMealCommand = new Command<SittingMeal>(async c => await SelectSittingMeal(c));

            SittingMeals = sitting.SittingMeals;

            //foreach (var sittingMeal in Sitting.SittingMeals)
            //    SittingMeals.Add(sittingMeal);
        }

        private async Task SelectSittingMeal(SittingMeal sittingMeal)
        {
            if (sittingMeal == null)
                return;
            SelectedSittingMeal = null;
            await _pageService.PushAsync(new SittingDetailPage(sittingMeal.Sitting));
        }
    }
}
