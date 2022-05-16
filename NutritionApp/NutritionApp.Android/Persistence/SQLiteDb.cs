using Android.OS;
using NutritionApp.Droid;
using NutritionApp.Persistence;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SQLiteDb))]
namespace NutritionApp.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            //Debug.WriteLine($"Database path:{path}");

            return new SQLiteAsyncConnection(path);
        }
    }
}