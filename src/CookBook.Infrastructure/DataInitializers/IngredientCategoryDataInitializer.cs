using System.Threading.Tasks;
using CookBook.Infrastructure.DataInitializers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.DataInitializers
{
    public class IngredientCategoryDataInitializer : IIngredientCategoryDataInitializer
    {
        private readonly IIngredientCategoryService _categoryService;

        public IngredientCategoryDataInitializer(IIngredientCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Initialize()
        {
            for (var i = 0; i < 10; i++)
            {
                var ingredientCategoryCreateDto = new IngredientCategoryCreateDto
                {
                    Name = $"Category{i + 1}"
                };
                await _categoryService.AddAsync(ingredientCategoryCreateDto);
            }
        }
    }
}
