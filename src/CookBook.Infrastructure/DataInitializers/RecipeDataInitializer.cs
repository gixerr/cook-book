using System.Threading.Tasks;
using CookBook.Infrastructure.DataInitializers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.DataInitializers
{
    public class RecipeDataInitializer : IRecipeDataInitializer
    {
        private readonly IRecipeService _recipeService;

        public RecipeDataInitializer(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task Initialize()
        {
            for (var i = 0; i < 10; i++)
            {
                var recipeCreateDto = new RecipeCreateDto
                {
                    CategoryName = $"Category-{i + 1}",
                    Name = $"Recipe-{i + 1}",
                    Preparation = "Cook it well!",
                    ShortDescription = "Cook it"
                };
                await _recipeService.AddAsync(recipeCreateDto);
            }
        }
    }
}
