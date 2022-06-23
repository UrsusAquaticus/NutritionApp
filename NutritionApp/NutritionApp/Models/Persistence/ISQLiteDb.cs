using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Persistence
{
    //Used to get the device specific implementation of SQLite database
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
