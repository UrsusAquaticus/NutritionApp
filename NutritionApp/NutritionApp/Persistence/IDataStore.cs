using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NutritionApp.Persistence
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T obj);
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<ObservableCollection<T>> GetAsync();
    }
}
