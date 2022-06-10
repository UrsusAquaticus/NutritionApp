
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
    public class SQLiteDatabase
    {
        private static SQLiteDatabase instance = null;
        private readonly ISQLiteDb db;
        private readonly SQLiteIngredientStore ingredientStore;
        private readonly SQLiteMealIngredientStore mealIngredientStore;
        private readonly SQLiteMealStore mealStore;
        private readonly SQLiteSittingMealStore sittingMealStore;
        private readonly SQLiteSittingStore sittingStore;
        private readonly SQLiteProfileStore profileStore;
        private readonly SQLiteGoalStore goalStore;

        private SQLiteDatabase()
        {
            db = DependencyService.Get<ISQLiteDb>();
            ingredientStore = SQLiteIngredientStore.GetInstance(db);
            mealIngredientStore = SQLiteMealIngredientStore.GetInstance(db);
            mealStore = SQLiteMealStore.GetInstance(db);
            sittingMealStore = SQLiteSittingMealStore.GetInstance(db);
            sittingStore = SQLiteSittingStore.GetInstance(db);
            profileStore = SQLiteProfileStore.GetInstance(db);
            goalStore = SQLiteGoalStore.GetInstance(db);
        }

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

        public SQLiteIngredientStore IngredientStore { get => ingredientStore; }
        public SQLiteMealIngredientStore MealIngredientStore { get => mealIngredientStore; }
        public SQLiteMealStore MealStore { get => mealStore; }
        public SQLiteSittingMealStore SittingMealStore { get => sittingMealStore; }
        public SQLiteSittingStore SittingStore { get => sittingStore; }
        public SQLiteProfileStore ProfileStore { get => profileStore; }
        public SQLiteGoalStore GoalStore { get => goalStore; }
    }
}
