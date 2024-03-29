﻿using NutritionApp.Models;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public class SQLiteMealStore : SQLiteDataStoreBase<Meal>
    {
        private static SQLiteMealStore Instance = null;

        private SQLiteMealStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteMealStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteMealStore(db);
            }
            return Instance;
        }
    }
}
