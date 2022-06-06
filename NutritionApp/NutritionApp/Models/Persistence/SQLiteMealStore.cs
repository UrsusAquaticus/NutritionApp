using NutritionApp.Models;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    class SQLiteMealStore : SQLiteDataStoreBase<Meal>
    {
        public SQLiteMealStore(ISQLiteDb db) : base(db)
        {
        }
    }
}
