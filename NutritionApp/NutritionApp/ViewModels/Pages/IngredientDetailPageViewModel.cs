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
        private readonly IDataStore<Ingredient> ingredientStore;
        private readonly IPageService pageService;
        public Ingredient Ingredient { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public IngredientDetailPageViewModel(Ingredient ingredient, IPageService pageService)
        {
            Ingredient = ingredient;
            this.pageService = pageService;

            ingredientStore = App.Database.IngredientStore;

            SaveCommand = new Command(async () => await Save());
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Ingredient.Name))
            {
                await pageService.DisplayAlert("Error", "Please enter ingredient name.", "OK");
                return;
            }
            if (Ingredient.Id == 0)
            {
                await ingredientStore.AddAsync(Ingredient);
                MessagingCenter.Send(this, Events.IngredientAdded, Ingredient);
            }
            else
            {
                await ingredientStore.UpdateAsync(Ingredient);
                MessagingCenter.Send(this, Events.IngredientUpdated, Ingredient);
            }
            await pageService.PopAsync();
        }
    }
}
