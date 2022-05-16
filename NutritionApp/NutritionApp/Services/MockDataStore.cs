using NutritionApp.Models;
using System;
using System.Collections.Generic;
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
        public async Task<bool> AddProfileAsync(Profile item)
        {
            profiles.Add(item);

            return await Task.FromResult(true);
        }

        // update profile
        public async Task<bool> UpdateProfileAsync(Profile item)
        {
            var oldItem = profiles.Where((Profile arg) => arg.Id == item.Id).FirstOrDefault();
            profiles.Remove(oldItem);
            profiles.Add(item);

            return await Task.FromResult(true);
        }

        // delete profile
        public async Task<bool> DeleteProfileAsync(int id)
        {
            var oldItem = profiles.Where((Profile arg) => arg.Id == id).FirstOrDefault();
            profiles.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Profile> GetProfileAsync(int id)
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
    }
}