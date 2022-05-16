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
        private int profileId;
        private string name;
        private string gender;
        public int Id { get; set; }

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

        public int ProfileId
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

        public async void LoadProfileId(int profileId)
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
