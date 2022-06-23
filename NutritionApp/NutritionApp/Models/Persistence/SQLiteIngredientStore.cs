using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public class SQLiteIngredientStore : SQLiteDataStoreBase<Ingredient>
    {
        private static SQLiteIngredientStore Instance = null;

        private SQLiteIngredientStore(ISQLiteDb db) : base(db)
        {
        }

        public static SQLiteIngredientStore GetInstance(ISQLiteDb db)
        {
            if (Instance == null)
            {
                Instance = new SQLiteIngredientStore(db);
            }
            return Instance;
        }
        public async override Task<int> Default()
        {
            var count = await base.Default();
            if (count <= 0)
            {
                await connection.InsertAllAsync(DefaultIngredients);
            }
            return count;
        }

        private List<Ingredient> DefaultIngredients
        {
            get
            {
                return new List<Ingredient>
                {
                    new Ingredient()
                    {
                        Name = "Apple",
                        ServingSizeGrams = 100,
                        Kj = 217.568f
                    },
                    new Ingredient()
                    {
                        Name = "Banana",
                        ServingSizeGrams = 100,
                        Kj = 372.376f
                    },
                    new Ingredient()
                    {
                        Name = "Carrot",
                        ServingSizeGrams = 100,
                        Kj = 171.544f
                    },
                    new Ingredient()
                    {
                        Name = "Date",
                        ServingSizeGrams = 100,
                        Kj = 1179.888f
                    },
                    new Ingredient()
                    {
                        Name = "Eggplant",
                        ServingSizeGrams = 100,
                        Kj = 104.6f
                    },
                    new Ingredient()
                    {
                        Name = "Sugar",
                        ServingSizeGrams = 100,
                        Kj = 1619.21f
                    },
                    new Ingredient()
                    {
                        Name = "Egg",
                        ServingSizeGrams = 100,
                        Kj = 648.52f
                    },
                    new Ingredient()
                    {
                        Name = "Milk",
                        ServingSizeGrams = 100,
                        Kj = 175.728f
                    }
                };
            }
        }
    }
}
