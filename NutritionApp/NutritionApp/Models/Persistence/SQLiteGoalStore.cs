using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public class SQLiteGoalStore : SQLiteDataStoreBase<Goal>
    {
        private static SQLiteGoalStore Instance = null;

        private SQLiteGoalStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteGoalStore Instantiate(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteGoalStore(db);
            }
            return Instance;
        }

        public static SQLiteGoalStore GetInstance()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("SQLiteGoalStore has not been Instantiated");
            }
            return Instance;
        }
    }
}
