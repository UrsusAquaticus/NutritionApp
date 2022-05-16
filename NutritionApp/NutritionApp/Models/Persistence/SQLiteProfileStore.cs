using NutritionApp.Models;

namespace NutritionApp.Persistence
{
    class SQLiteProfileStore : SQLiteDataStoreBase<Profile>
    {
        public SQLiteProfileStore(ISQLiteDb db) : base(db)
        {
        }
    }
}
