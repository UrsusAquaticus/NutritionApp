﻿using NutritionApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace NutritionApp.Persistence
{
    //Abstract class to simplify and standardise implementation of accessing SQLite
    public abstract class SQLiteDataStoreBase<T> : IDataStore<T> where T : new()
    {
        protected SQLiteAsyncConnection connection;

        public SQLiteDataStoreBase(ISQLiteDb db)
        {
            connection = db.GetConnection();
            connection.CreateTableAsync<T>();
            //connection.DeleteAllAsync<T>();

            //Fire and forget
            _ = Default();
        }

        //Create
        public virtual async Task<int> AddAsync(T obj)
        {
            return await connection.InsertAsync(obj);
        }
        public virtual async Task AddWithChildrenAsync(T obj)
        {
            await connection.InsertOrReplaceWithChildrenAsync(obj, true);
        }

        //Read
        public virtual async Task<T> GetAsync(int id)
        {
            return await connection.FindAsync<T>(id);
        }
        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await connection.Table<T>().ToListAsync();
        }
        public virtual async Task<T> GetWithChildrenAsync(int id)
        {
            return await connection.GetWithChildrenAsync<T>(id, true);
        }
        public virtual async Task<IEnumerable<T>> GetAllWithChildrenAsync()
        {
            return await connection.GetAllWithChildrenAsync<T>();
        }

        //Update
        public virtual async Task<int> UpdateAsync(T obj)
        {
            return await connection.UpdateAsync(obj);
        }
        public virtual async Task UpdateWithChildrenAsync(T obj)
        {
            await connection.InsertOrReplaceWithChildrenAsync(obj, true);
        }

        //Delete
        public virtual async Task<int> DeleteAsync(T obj)
        {
            return await connection.DeleteAsync(obj);
        }

        public virtual async Task<int> Default()
        {
            var count = await connection.Table<T>().CountAsync();
            Console.WriteLine(typeof(T).ToString() + ": " + count + " Records");
            return count;
        }
    }
}
