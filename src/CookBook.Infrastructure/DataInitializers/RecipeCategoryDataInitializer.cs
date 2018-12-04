using System.Threading.Tasks;
using CookBook.Infrastructure.DataInitializers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.DataInitializers
{
    public class RecipeCategoryDataInitializer : IRecipeCategoryDataInitializer
    {
        private readonly IRecipeCategoryService _categoryService;

        public RecipeCategoryDataInitializer(IRecipeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task Initialize()
        {
            for (var i = 0; i < 10; i++)
            {
                var recipeCategoryCreateDto = new RecipeCategoryCreateDto
                {
                    Name = $"Category-{i + 1}"
                };
                await _categoryService.AddAsync(recipeCategoryCreateDto);
            }
        }
    }
}
