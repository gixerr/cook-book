using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.IngredientCategories
{
    public class CreateIngredientCategoryHandler : ICommandHandler<IngredientCategoryCreateDto>
    {
        private readonly IIngredientCategoryService _categoryService;

        public CreateIngredientCategoryHandler(IIngredientCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(IngredientCategoryCreateDto command) 
            => await _categoryService.AddAsync(command);
    }
}
