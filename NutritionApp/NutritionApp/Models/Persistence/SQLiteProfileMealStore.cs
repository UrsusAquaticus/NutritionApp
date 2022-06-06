using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public class SQLiteProfileMealStore : SQLiteDataStoreBase<ProfileMeal>
    {
        private static SQLiteProfileMealStore Instance = null;

        private SQLiteProfileMealStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteProfileMealStore Instantiate(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteProfileMealStore(db);
            }
            return Instance;
        }
        public static SQLiteProfileMealStore GetInstance()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("SQLiteProfileMealStore has not been Instantiated");
            }
            return Instance;
        }
    }
}
