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

        public static SQLiteMealIngredientStore Instantiate(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteMealIngredientStore(db);
            }
            return Instance;
        }

        public static SQLiteMealIngredientStore GetInstance()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("SQLiteMealIngredientStore has not been Instantiated");
            }
            return Instance;
        }
    }
}
