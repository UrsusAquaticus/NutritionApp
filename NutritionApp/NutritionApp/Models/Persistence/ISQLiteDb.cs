using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
