using NutritionApp.Models;

namespace NutritionApp.Persistence
{
    class SQLiteMealStore : SQLiteDataStoreBase<Meal>
    {
        public SQLiteMealStore(ISQLiteDb db) : base(db)
        {
        }
    }
}
