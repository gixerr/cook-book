using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.RecipeCategories
{
    public class RemoveRecipeCategoryHandler : ICommandHandler<RecipeCategoryRemoveDto>
    {
        private readonly IRecipeCategoryService _categoryService;

        public RemoveRecipeCategoryHandler(IRecipeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(RecipeCategoryRemoveDto command)
            => await _categoryService.RemoveAsync(command.Id);
    }
}
