using NutritionApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace NutritionApp.Persistence
{
    public abstract class SQLiteDataStoreBase<T> : IDataStore<T> where T : new()
    {
        protected SQLiteAsyncConnection connection;

        public SQLiteDataStoreBase(ISQLiteDb db)
        {
            connection = db.GetConnection();
            connection.CreateTableAsync<T>();
            //connection.DeleteAllAsync<T>();
        }

        public virtual async Task<int> AddAsync(T obj)
        {
            return await connection.InsertAsync(obj);
        }

        public virtual async Task AddWithChildrenAsync(T obj)
        {
            await connection.InsertOrReplaceWithChildrenAsync(obj, true);
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            return await connection.DeleteAsync(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await connection.FindAsync<T>(id);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await connection.Table<T>().ToListAsync();
        }

        public virtual async Task<int> UpdateAsync(T obj)
        {
            return await connection.UpdateAsync(obj);
        }
    }
}
