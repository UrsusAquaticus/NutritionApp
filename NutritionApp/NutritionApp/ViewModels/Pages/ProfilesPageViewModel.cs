﻿using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class ProfilesPageViewModel : BaseViewModel
    {
        //https://medium.com/swlh/xamarin-forms-mvvm-how-to-work-with-sqlite-db-c-xaml-26fcae303edd
        //Look here for how to implement the custom interface 'IPageService'
        private ProfileViewModel _selectedProfile;
        private IDataStore<Profile> _profileStore;
        //private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<ProfileViewModel> Profiles { get; private set; }
            = new ObservableCollection<ProfileViewModel>();

        public ProfileViewModel SelectedProfile
        {
            get { return _selectedProfile; }
            set { SetValue(ref _selectedProfile, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddProfileCommand { get; private set; }
        public ICommand SelectProfileCommand { get; private set; }
        public ICommand DeleteProfileCommand { get; private set; }
        public ICommand CallProfileCommand { get; private set; }

        //public ProfilesPageViewModel(IDataStore<Profile> profileStore, IPageService pageService)
        public ProfilesPageViewModel(IDataStore<Profile> profileStore)
        {
            _profileStore = profileStore;
            //_pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddProfileCommand = new Command(async () => await AddProfile());
            SelectProfileCommand = new Command<ProfileViewModel>(async c => await SelectProfile(c));
            DeleteProfileCommand = new Command<ProfileViewModel>(async c => await DeleteProfile(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;
            var profiles = await _profileStore.GetAsync();
            foreach (var profile in profiles)
                Profiles.Add(new ProfileViewModel(profile));
        }

        private async Task AddProfile()
        {
            //await _pageService.PushAsync(new ProfilesDetailPage(new ProfileViewModel()));
            await _profileStore.AddAsync(new Profile { Id = 1, Name = "Zach", Pregnant = true }); //temp, have not implemented messaging to update list yet. Requires app reload to view changes
        }

        private async Task SelectProfile(ProfileViewModel profile)
        {
            if (profile == null)
                return;

            SelectedProfile = null;
            //await _pageService.PushAsync(new ProfilesDetailPage(profile));
            await new Task(() => { Console.WriteLine("Hasn't been implemented yet lol"); });
        }

        private async Task DeleteProfile(ProfileViewModel profileViewModel)
        {
            //if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {profileViewModel.FullName}?", "Yes", "No"))
            //{
            //    Profiles.Remove(profileViewModel);

            //    var profile = await _profileStore.GetProfile(profileViewModel.Id);
            //    await _profileStore.DeleteProfile(profile);
            //}
            await new Task(() => { Console.WriteLine("Hasn't been implemented yet lol"); });
        }
    }
}
