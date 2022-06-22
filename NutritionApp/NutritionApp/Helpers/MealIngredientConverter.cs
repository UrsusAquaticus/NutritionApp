using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace NutritionApp.Helpers
{
    public class MealIngredientConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0]!=null && values[1]!=null && values.Length == 2)
            {
                var str = values[1].ToString();
                if (str.Length == 0) return null;
                float nos = float.Parse(str);
                if (nos <= 0) return null;
                Ingredient ingredient = (Ingredient)values[0];
                return new MealIngredient { Ingredient = ingredient, NumberOfServings = nos };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
