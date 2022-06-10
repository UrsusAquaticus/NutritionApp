using NutritionApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public class SQLiteSittingStore : SQLiteDataStoreBase<Sitting>
    {
        private static SQLiteSittingStore Instance = null;

        private SQLiteSittingStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteSittingStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteSittingStore(db);
            }
            return Instance;
        }
    }
}
