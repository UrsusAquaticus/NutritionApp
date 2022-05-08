using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        public IndexViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}