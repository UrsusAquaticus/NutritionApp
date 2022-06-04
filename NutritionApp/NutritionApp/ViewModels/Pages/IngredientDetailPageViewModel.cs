using NutritionApp.Models;
using NutritionApp.Persistence;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.ViewModels
{
    public class IngredientDetailPageViewModel : BaseViewModel
    {
        private readonly IDataStore<Ingredient> _ingredientStore;
        private readonly IPageService _pageService;
        public Ingredient Ingredient { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public IngredientDetailPageViewModel(IngredientVM viewModel, IDataStore<Ingredient> ingredientStore, IPageService pageService)
        {
            _ingredientStore = ingredientStore;
            _pageService = pageService;

            SaveCommand = new Command(async () => await Save());

            Ingredient = new Ingredient
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ServingSizeGrams = viewModel.ServingSizeGrams,
                Kj = viewModel.Kj
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Ingredient.Name))
            {
                await _pageService.DisplayAlert("Error", "Please enter ingredient name.", "OK");
                return;
            }
            if (Ingredient.Id == 0)
            {
                await _ingredientStore.AddAsync(Ingredient);
                MessagingCenter.Send(this, Events.IngredientAdded, Ingredient);
            }
            else
            {
                await _ingredientStore.UpdateAsync(Ingredient);
                MessagingCenter.Send(this, Events.IngredientUpdated, Ingredient);
            }
            await _pageService.PopAsync();
        }
    }
}
