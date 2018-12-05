using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.IngredientCategories
{
    public class RemoveIngredientCategoryHandler : ICommandHandler<IngredientCategoryRemoveDto>
    {
        private readonly IIngredientCategoryService _categoryService;

        public RemoveIngredientCategoryHandler(IIngredientCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(IngredientCategoryRemoveDto command)
            => await _categoryService.RemoveAsync(command.Id); 
    }
}
