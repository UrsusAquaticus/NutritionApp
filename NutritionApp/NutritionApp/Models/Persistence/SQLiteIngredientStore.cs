using NutritionApp.Models;
using System;

namespace NutritionApp.Persistence
{
    public class SQLiteIngredientStore : SQLiteDataStoreBase<Ingredient>
    {
        private static SQLiteIngredientStore Instance = null;

        private SQLiteIngredientStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteIngredientStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteIngredientStore(db);
            }
            return Instance;
        }
    }
}
