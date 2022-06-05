using NutritionApp.Models;

namespace NutritionApp.Persistence
{
    class SQLiteIngredientStore : SQLiteDataStoreBase<Ingredient>
    {
        public SQLiteIngredientStore(ISQLiteDb db) : base(db)
        {
        }
    }
}
