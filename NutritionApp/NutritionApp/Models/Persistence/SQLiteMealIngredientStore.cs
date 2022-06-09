using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public sealed class SQLiteMealIngredientStore : SQLiteDataStoreBase<MealIngredient>
    {
        private static SQLiteMealIngredientStore Instance = null;

        private SQLiteMealIngredientStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteMealIngredientStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteMealIngredientStore(db);
            }
            return Instance;
        }
    }
}
