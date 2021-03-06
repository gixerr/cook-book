using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.RecipeCategories
{
    public class UpdateRecipeCategoryHandler : ICommandHandler<RecipeCategoryUpdateDto>
    {
        private readonly IRecipeCategoryService _categoryService;

        public UpdateRecipeCategoryHandler(IRecipeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(RecipeCategoryUpdateDto command)
            => await _categoryService.UpdateAsync(command);
    }
}
