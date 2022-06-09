using NutritionApp.Models;
using NutritionApp.Persistence;
using NutritionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NutritionApp.Views
{
    public partial class ProfileDetailPage : ContentPage
    {
        public ProfileDetailPage(Profile profile)
        {
            InitializeComponent();
            var pageService = new PageService();
            Title = (profile.Id == 0) ? "New Profile" : "Edit Profile";
            BindingContext = new ProfileDetailPageViewModel(profile ?? new Profile(), pageService);
        }
    }
}