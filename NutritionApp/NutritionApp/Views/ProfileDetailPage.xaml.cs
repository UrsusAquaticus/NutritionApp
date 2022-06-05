using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class ProfileDetailPage : ContentPage
    {
        public ProfileDetailPage(ProfileVM viewModel)
        {
            InitializeComponent();

            var profileStore = new SQLiteProfileStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Id == 0) ? "New Profile" : "Edit Profile";
            BindingContext = new ProfileDetailPageViewModel(viewModel ?? new ProfileVM(), profileStore, pageService);
        }
    }
}