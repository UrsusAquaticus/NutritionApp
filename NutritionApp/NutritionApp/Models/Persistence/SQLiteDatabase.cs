
using NutritionApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionApp.Persistence
{
    //Singleton class for data access
    public class SQLiteDatabase
    {
        private static SQLiteDatabase instance = null;
        private readonly ISQLiteDb _db;
        private readonly SQLiteIngredientStore _ingredientStore;
        private readonly SQLiteMealIngredientStore _mealIngredientStore;
        private readonly SQLiteMealStore _mealStore;
        private readonly SQLiteSittingMealStore _sittingMealStore;
        private readonly SQLiteSittingStore _sittingStore;
        private readonly SQLiteProfileStore _profileStore;
        private readonly SQLiteGoalStore _goalStore;

        //Private so it can only be returned from SQLiteDatabase.Instance
        private SQLiteDatabase()
        {
            _db = DependencyService.Get<ISQLiteDb>();
            _ingredientStore = SQLiteIngredientStore.GetInstance(_db);
            _mealIngredientStore = SQLiteMealIngredientStore.GetInstance(_db);
            _mealStore = SQLiteMealStore.GetInstance(_db);
            _sittingMealStore = SQLiteSittingMealStore.GetInstance(_db);
            _sittingStore = SQLiteSittingStore.GetInstance(_db);
            _profileStore = SQLiteProfileStore.GetInstance(_db);
            _goalStore = SQLiteGoalStore.GetInstance(_db);
        }

        //The accessor for getting the singleton
        public static SQLiteDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteDatabase();
                }
                return instance;
            }
        }

        public SQLiteIngredientStore IngredientStore { get => _ingredientStore; }
        public SQLiteMealIngredientStore MealIngredientStore { get => _mealIngredientStore; }
        public SQLiteMealStore MealStore { get => _mealStore; }
        public SQLiteSittingMealStore SittingMealStore { get => _sittingMealStore; }
        public SQLiteSittingStore SittingStore { get => _sittingStore; }
        public SQLiteProfileStore ProfileStore { get => _profileStore; }
        public SQLiteGoalStore GoalStore { get => _goalStore; }
    }
}
