using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddProfileAsync(T profile);
        Task<bool> UpdateProfileAsync(T profile);
        Task<bool> DeleteProfileAsync(int id);
        Task<T> GetProfileAsync(int id);
        Task<IEnumerable<T>> GetProfilesAsync(bool forceRefresh = false);
    }
}
