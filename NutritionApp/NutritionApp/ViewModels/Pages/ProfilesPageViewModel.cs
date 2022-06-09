﻿using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class ProfilesPageViewModel : BaseViewModel
    {
        //https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
        //Look here for how to implement the custom interface 'IPageService'
        private Profile selectedProfile;
        private readonly IDataStore<Profile> profileStore;
        private readonly IPageService pageService;

        private bool isDataLoaded;

        private ObservableCollection<Profile> profiles { get; set; } = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> Profiles
        {
            get
            {
                return profiles;
            }
            set
            {
                profiles = value;
                OnPropertyChanged();
            }
        }

        public Profile SelectedProfile
        {
            get { return selectedProfile; }
            set { SetValue(ref selectedProfile, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddProfileCommand { get; private set; }
        public ICommand SelectProfileCommand { get; private set; }
        public ICommand DeleteProfileCommand { get; private set; }
        public ICommand FilterProfileCommand { get; private set; }

        public ProfilesPageViewModel(IPageService _pageService)
        {
            profileStore = App.Database.ProfileStore;
            pageService = _pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddProfileCommand = new Command(async () => await AddProfile());
            SelectProfileCommand = new Command<Profile>(async c => await SelectProfile(c));
            DeleteProfileCommand = new Command<Profile>(async c => await DeleteProfile(c));
            FilterProfileCommand = new Command<string>(async c => await FilterProfile(c));

            MessagingCenter.Subscribe<ProfileDetailPageViewModel, Profile>(this, Events.ProfileAdded, OnProfileAdded);
            MessagingCenter.Subscribe<ProfileDetailPageViewModel, Profile>(this, Events.ProfileUpdated, OnProfileUpdated);
        }

        private void OnProfileAdded(ProfileDetailPageViewModel source, Profile profile)
        {
            Profiles.Add(profile);
        }
        private void OnProfileUpdated(ProfileDetailPageViewModel source, Profile profile)
        {
            var profileInList = Profiles.Single(c => c.Id == profile.Id);
            profileInList.Name = profile.Name;
            profileInList.DOB = profile.DOB;
            profileInList.Gender = profile.Gender;
            profileInList.Weight = profile.Weight;
            profileInList.Height = profile.Height;
            profileInList.Activity = profile.Activity;
            profileInList.Pregnant = profile.Pregnant;
        }

        private async Task LoadData()
        {
            if (isDataLoaded)
                return;
            isDataLoaded = true;
            var profiles = await profileStore.GetAsync();
            foreach (var profile in profiles)
                Profiles.Add(profile);
        }

        private async Task AddProfile()
        {
            await pageService.PushAsync(new ProfileDetailPage(new Profile()));
            //await _profileStore.AddAsync(new Profile { Id = 1, Name = "Zach", Pregnant = true }); //temp, have not implemented messaging to update list yet. Requires app reload to view changes
        }

        private async Task SelectProfile(Profile profile)
        {
            if (profile == null)
                return;
            SelectedProfile = null;
            await pageService.PushAsync(new ProfileDetailPage(profile));
        }

        private async Task DeleteProfile(Profile profileViewModel)
        {
            if (await pageService.DisplayAlert("Warning", $"Are you sure you want to delete {profileViewModel.Name}?", "Yes", "No"))
            {
                Profiles.Remove(profileViewModel);
                var profile = await profileStore.GetAsync(profileViewModel.Id);
                await profileStore.DeleteAsync(profile.Id);
            }
        }

        // perform search using a viewmodel... https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar#perform-a-search-using-a-viewmodel
        public async Task FilterProfile(string queryString)
        {
            // check if queryString is null, if not put to lower, if null return empty string
            var normalizedQuery = queryString?.ToLower() ?? "";
            var profiles = await profileStore.GetAsync();
            if (!string.IsNullOrEmpty(normalizedQuery))
            {
                profiles = profiles.Where(p => p.Name.ToLowerInvariant().Contains(normalizedQuery));
            }
            Profiles.Clear();
            foreach (var profile in profiles)
                Profiles.Add(profile);
        }
    }
}
