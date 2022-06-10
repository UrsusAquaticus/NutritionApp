using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public class SQLiteSittingMealStore : SQLiteDataStoreBase<SittingMeal>
    {
        private static SQLiteSittingMealStore Instance = null;

        private SQLiteSittingMealStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteSittingMealStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteSittingMealStore(db);
            }
            return Instance;
        }
    }
}
