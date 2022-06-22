using System;
using Xunit;
using Moq;
using NutritionApp.ViewModels;
using NutritionApp.Persistence;
using NutritionApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NutritionAppTestProject
{
    public sealed class ProfilesPageViewModelTests
    {
        private readonly MockRepository _mockRepository;
        private readonly ProfilesPageViewModel _profilesPageViewModel;
        private readonly Mock<IDataStore<Profile>> _profileStore;
        private readonly Mock<IPageService> _pageService;


        public ProfilesPageViewModelTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            _profileStore = _mockRepository.Create<IDataStore<Profile>>();
            _pageService = _mockRepository.Create<IPageService>();

            _profileStore
                .Setup(x => x.GetAsync().Result)
                .Returns(TestGetAllAsyncData());

            _profilesPageViewModel = new ProfilesPageViewModel(_profileStore.Object, _pageService.Object);
        }

        public static IEnumerable<Profile> TestGetAllAsyncData()
        {
            return new ObservableCollection<Profile>
            {
                new Profile
                {
                    Id = 1,
                    Name = "John"
                },
                new Profile
                {
                    Id = 2,
                    Name = "Jacob"
                },
                new Profile
                {
                    Id = 3,
                    Name = "Jingleheimer"
                },
                new Profile
                {
                    Id = 4,
                    Name = "Schmidt"
                },
            };
        }

        [Fact]
        public async void LoadDataCommand_sets_Profiles_with_4_records()
        {
            await _profilesPageViewModel.LoadData();
            var profilesCount = _profilesPageViewModel.Profiles.Count;
            _mockRepository.VerifyAll();
            Assert.Equal(4, profilesCount);
        }
    }
}
