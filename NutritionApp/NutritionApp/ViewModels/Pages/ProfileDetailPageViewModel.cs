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
        private readonly IDataStore<Profile> _profileStore;
        private readonly IPageService _pageService;
        public Profile Profile { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ProfileDetailPageViewModel(ProfileViewModel viewModel, IDataStore<Profile> profileStore, IPageService pageService)
        {
            _profileStore = profileStore;
            _pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Profile = new Profile
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                DOB = viewModel.DOB,
                Gender = viewModel.Gender,
                Weight = viewModel.Weight,
                Height = viewModel.Height,
                Activity = viewModel.Activity,
                Pregnant = viewModel.Pregnant
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Profile.Name))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            if (Profile.Id == 0)
            {
                await _profileStore.AddAsync(Profile);
                MessagingCenter.Send(this, Events.ProfileAdded, Profile);
            }
            else
            {
                await _profileStore.UpdateAsync(Profile);
                MessagingCenter.Send(this, Events.ProfileUpdated, Profile);
            }
            await _pageService.PopAsync();
        }
    }
}
