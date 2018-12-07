using System.Threading.Tasks;
using CookBook.Infrastructure.DataInitializers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.DataInitializers
{
    public class IngredientDataInitializer : IIngredientDataInitializer
    {
        private readonly IIngredientService _ingredientService;

        public IngredientDataInitializer(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task Initialize()
        {
            for (var i = 0; i < 10; i++)
            {
                var ingredientCreateDto = new IngredientCreateDto
                {
                    CategoryName = $"Category-{i + 1}",
                    Name = $"Ingredient-{i + 1}"
                };
                await _ingredientService.AddAsync(ingredientCreateDto);
            }
        }
    }
}
