using NutritionApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    [QueryProperty(nameof(ProfileId), nameof(ProfileId))]
    public class ProfileDetailViewModel : BaseViewModel
    {
        private string profileId;
        private string name;
        private string gender;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public string ProfileId
        {
            get
            {
                return profileId;
            }
            set
            {
                profileId = value;
                LoadProfileId(value);
            }
        }

        public async void LoadProfileId(string profileId)
        {
            try
            {
                var item = await DataStore.GetProfileAsync(profileId);
                Id = item.Id;
                Name = item.Name;
                Gender = item.Gender;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
