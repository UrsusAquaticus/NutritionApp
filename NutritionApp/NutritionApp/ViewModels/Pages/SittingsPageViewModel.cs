using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class SittingsPageViewModel : BaseViewModel
    {
        private Sitting selectedSitting;
        private readonly IDataStore<Sitting> _sittingStore;
        public Profile Profile { get; private set; }


        private readonly IPageService pageService;
        public ICommand AddSittingCommand { get; private set; }
        public ICommand EditProfileCommand { get; private set; }
        public ICommand SelectSittingCommand { get; private set; }

        public Sitting SelectedSitting
        {
            get { return selectedSitting; }
            set { SetValue(ref selectedSitting, value); }
        }

        public SittingsPageViewModel(Profile profile, IPageService _pageService)
        {
            Profile = profile;
            pageService = _pageService;
            _sittingStore = App.Database.SittingStore;

            AddSittingCommand = new Command(async () => await AddSitting());
            EditProfileCommand = new Command<Profile>(async c => await EditProfile(c));
            SelectSittingCommand = new Command<Sitting>(async c => await SelectSitting(c));


            MessagingCenter.Subscribe<SittingDetailPageViewModel, Sitting>(this, Events.SittingAdded, OnSittingAdded);
            MessagingCenter.Subscribe<SittingDetailPageViewModel, Sitting>(this, Events.SittingUpdated, OnSittingUpdated);
        }

        public SittingsPageViewModel(PageService pageService)
        {
            this.pageService = pageService;
        }

        private void OnSittingAdded(SittingDetailPageViewModel source, Sitting sitting)
        {
            Profile.Sittings.Add(sitting);
        }
        private void OnSittingUpdated(SittingDetailPageViewModel source, Sitting sitting)
        {
            var sittingInList = Profile.Sittings.Single(c => c.Id == sitting.Id);
            sittingInList = sitting;
        }

        private async Task AddSitting()
        {
            await pageService.PushAsync(new SittingDetailPage(
                new Sitting
                {
                    ProfileId = Profile.Id,
                    Time = DateTime.Now.TimeOfDay,
                    Date = DateTime.Now.Date
                }));
        }

        private async Task SelectSitting(Sitting sitting)
        {
            if (sitting == null)
                return;
            SelectedSitting = null;
            var _sitting = await _sittingStore.GetWithChildrenAsync(sitting.Id);
            await pageService.PushAsync(new SittingMealsPage(_sitting));
        }

        // null profile
        private async Task EditProfile(Profile profile)
        {
            if (profile == null)
                return;

            await pageService.PushAsync(new ProfileDetailPage(profile));
        }
    }

}
