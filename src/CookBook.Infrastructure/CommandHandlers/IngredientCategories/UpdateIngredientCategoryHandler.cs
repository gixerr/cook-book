using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.IngredientCategories
{
    public class UpdateIngredientCategoryHandler : ICommandHandler<IngredientCategoryUpdateDto>
    {
        private readonly IIngredientCategoryService _categoryService;

        public UpdateIngredientCategoryHandler(IIngredientCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(IngredientCategoryUpdateDto command) 
            => await _categoryService.UpdateAsync(command);
    }
}
