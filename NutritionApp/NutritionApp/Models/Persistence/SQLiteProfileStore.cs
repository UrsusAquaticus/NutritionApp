﻿using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public class SQLiteProfileStore : SQLiteDataStoreBase<Profile>
    {
        private static SQLiteProfileStore Instance = null;

        private SQLiteProfileStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteProfileStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteProfileStore(db);
            }
            return Instance;
        }
    }
}
