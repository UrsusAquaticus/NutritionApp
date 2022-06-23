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
    public sealed class IngredientsPageViewModelTests
    {
        private readonly MockRepository _mockRepository;
        private readonly IngredientsPageViewModel _ingredientsPageViewModel;
        private readonly Mock<IDataStore<Ingredient>> _ingredientStore;
        private readonly Mock<IPageService> _pageService;


        public IngredientsPageViewModelTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            _ingredientStore = _mockRepository.Create<IDataStore<Ingredient>>();
            _pageService = _mockRepository.Create<IPageService>();

            _ingredientStore
                .Setup(x => x.GetAsync().Result)
                .Returns(TestGetAllAsyncData());

            _ingredientsPageViewModel = new IngredientsPageViewModel(_ingredientStore.Object, _pageService.Object);
        }

        public static IEnumerable<Ingredient> TestGetAllAsyncData()
        {
            return new ObservableCollection<Ingredient>
            {
                new Ingredient
                {
                    Id = 1,
                    Name = "Apple"
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Banana"
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Carrot"
                },
                new Ingredient
                {
                    Id = 4,
                    Name = "Dragon Fruit"
                },
            };
        }

        [Fact]
        public async void LoadDataCommand_sets_Ingredients_with_4_records()
        {
            await _ingredientsPageViewModel.LoadData();
            var ingredientsCount = _ingredientsPageViewModel.Ingredients.Count;
            _mockRepository.VerifyAll();
            Assert.Equal(4, ingredientsCount);
        }
    }
}
