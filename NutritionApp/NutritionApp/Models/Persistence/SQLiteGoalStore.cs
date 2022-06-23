using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public class SQLiteGoalStore : SQLiteDataStoreBase<Goal>
    {
        private static SQLiteGoalStore Instance = null;

        private SQLiteGoalStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteGoalStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteGoalStore(db);
            }
            return Instance;
        }
    }
}
