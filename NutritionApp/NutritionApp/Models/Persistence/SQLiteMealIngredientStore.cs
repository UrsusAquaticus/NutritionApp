using NutritionApp.Models;

namespace NutritionApp.Persistence
{
    class SQLiteMealIngredientStore : SQLiteDataStoreBase<MealIngredient>
    {
        public SQLiteMealIngredientStore(ISQLiteDb db) : base(db)
        {
        }
    }
}
