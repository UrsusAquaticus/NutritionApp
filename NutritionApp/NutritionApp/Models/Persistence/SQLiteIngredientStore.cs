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

        public static SQLiteIngredientStore Instantiate(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteIngredientStore(db);
            }
            return Instance;
        }

        public static SQLiteIngredientStore GetInstance()
        {
            if (Instance == null)
            {
                throw new InvalidOperationException("SQLiteIngredientStore has not been Instantiated");
            }
            return Instance;
        }
    }
}
