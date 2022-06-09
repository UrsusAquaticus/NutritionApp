using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public interface IDataStore<T>
    {
        //Create
        Task<int> AddAsync(T obj);
        Task AddWithChildrenAsync(T obj);
        //Read
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetWithChildrenAsync(int id);
        Task<IEnumerable<T>> GetAllWithChildrenAsync();
        //Update
        Task<int> UpdateAsync(T obj);
        Task UpdateWithChildrenAsync(T obj);
        //Delete
        Task<int> DeleteAsync(int id);

    }
}
