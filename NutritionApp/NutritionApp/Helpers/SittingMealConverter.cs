using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace NutritionApp.Helpers
{
    class SittingMealConverter : IMultiValueConverter
    {
        //These are used in MultiBinding so that multiple parameters can be passed into a command
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Values[0] should be a Meal
            //Values[1] should be a float
            if (values[0] != null && values[1] != null && values.Length == 2)
            {
                var str = values[1].ToString();
                if (str.Length == 0) return null;
                float nos = float.Parse(str);
                if (nos <= 0) return null;
                Meal meal = (Meal)values[0];
                return new SittingMeal { Meal = meal, NumberOfServings = nos };
            }
            return null;
        }

        //Not used
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
