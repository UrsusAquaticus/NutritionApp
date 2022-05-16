using NutritionApp.Models;

namespace NutritionApp.Persistence
{
    class SQLiteProfile : SQLiteDataStoreBase<Profile>
    {
        public SQLiteProfile(ISQLiteDb db) : base(db)
        {
        }
    }
}
