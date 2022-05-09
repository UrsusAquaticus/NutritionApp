using NutritionApp.Models;
using NutritionApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private Profile _selectedProfile;

        public ObservableCollection<Profile> Profiles { get; }
        public Command LoadProfilesCommand { get; }
        public Command AddProfileCommand { get; }
        public Command<Profile> ProfileTapped { get; }

        public ProfileViewModel()
        {
            Title = "Profiles";
            Profiles = new ObservableCollection<Profile>();
            LoadProfilesCommand = new Command(async () => await ExecuteLoadProfilesCommand());

            ProfileTapped = new Command<Profile>(OnProfileSelected);

            AddProfileCommand = new Command(OnAddProfile);
        }

        async Task ExecuteLoadProfilesCommand()
        {
            IsBusy = true;

            try
            {
                Profiles.Clear();
                var profiles = await DataStore.GetProfilesAsync(true);
                foreach (var profile in profiles)
                {
                    Profiles.Add(profile);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Profile SelectedItem
        {
            get => _selectedProfile;
            set
            {
                SetProperty(ref _selectedProfile, value);
                OnProfileSelected(value);
            }
        }

        // redirects to new profile page
        private async void OnAddProfile(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewProfilePage));
        }


        // goes to the detailed view of the selected profile
        async void OnProfileSelected(Profile item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}?{nameof(ProfileDetailViewModel.ProfileId)}={item.Id}");
        }
    }
}