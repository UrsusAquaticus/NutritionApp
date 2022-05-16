using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionApp.Services
{
    public class MockDataStore : IDataStore<Profile>
    {
        readonly List<Profile> profiles;

        public MockDataStore()
        {
            profiles = new List<Profile>()
            {
                new Profile { Id = 1, Name = "Dani JS", Gender="F"},
                new Profile { Id = 2, Name = "Zach H", Gender="M"}

            };
        }

        // create profile
        public async Task<bool> AddAsync(Profile item)
        {
            profiles.Add(item);

            return await Task.FromResult(true);
        }

        // update profile
        public async Task<bool> UpdateAsync(Profile item)
        {
            var oldItem = profiles.Where((Profile arg) => arg.Id == item.Id).FirstOrDefault();
            profiles.Remove(oldItem);
            profiles.Add(item);

            return await Task.FromResult(true);
        }

        // delete profile
        public async Task<bool> DeleteAsync(int id)
        {
            var oldItem = profiles.Where((Profile arg) => arg.Id == id).FirstOrDefault();
            profiles.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Profile> GetAsync(int id)
        {
            return await Task.FromResult(profiles.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Profile>> GetProfilesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(profiles);
        }

        public Task<bool> DeleteProfileAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> GetProfileAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Profile>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}