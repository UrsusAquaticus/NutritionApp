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
            Profile = profile;
            this.pageService = pageService;

            profileStore = App.Database.ProfileStore;

            SaveCommand = new Command(async () => await Save());
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
