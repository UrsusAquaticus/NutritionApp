using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NutritionApp.ViewModels.Tables
{
    class MealVM : BaseViewModel
    {
        private int id;
        private ObservableCollection<ProfileViewModel> mealIngredient;

        //
        private string name;
        private float servingSizeGrams;
    }
}
