using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public interface IDataStore<T>
    {
        Task<int> AddAsync(T obj);
        Task<int> UpdateAsync(T obj);
        Task<int> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
        Task AddWithChildrenAsync(T obj);
    }
}
