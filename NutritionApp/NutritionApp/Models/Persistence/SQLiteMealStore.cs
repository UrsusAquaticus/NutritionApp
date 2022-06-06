using NutritionApp.Models;
using System;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public class SQLiteMealStore : SQLiteDataStoreBase<Meal>
    {
        private static SQLiteMealStore Instance = null;

        private SQLiteMealStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteMealStore Instantiate(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteMealStore(db);
            }
            return Instance;
        }

        public static SQLiteMealStore GetInstance()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("SQLiteMealStore has not been Instantiated");
            }
            return Instance;
        }
    }
}
