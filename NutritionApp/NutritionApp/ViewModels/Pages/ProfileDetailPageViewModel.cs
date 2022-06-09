using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class ProfileDetailPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Profile> profileStore;
        private readonly IPageService pageService;
        public Profile Profile { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ProfileDetailPageViewModel(Profile profile, IPageService pageService)
        {
            profileStore = App.Database.ProfileStore;
            this.pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Profile = new Profile
            {
                Id = profile.Id,
                Name = profile.Name,
                DOB = profile.DOB,
                Gender = profile.Gender,
                Weight = profile.Weight,
                Height = profile.Height,
                Activity = profile.Activity,
                Pregnant = profile.Pregnant
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Profile.Name))
            {
                await pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            if (Profile.Id == 0)
            {
                await profileStore.AddAsync(Profile);
                MessagingCenter.Send(this, Events.ProfileAdded, Profile);
            }
            else
            {
                await profileStore.UpdateAsync(Profile);
                MessagingCenter.Send(this, Events.ProfileUpdated, Profile);
            }
            await pageService.PopAsync();
        }
    }
}
