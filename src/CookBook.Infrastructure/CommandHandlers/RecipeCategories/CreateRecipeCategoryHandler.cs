using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.RecipeCategories
{
    public class CreateRecipeCategoryHandler : ICommandHandler<RecipeCategoryCreateDto>
    {
        private readonly IRecipeCategoryService _categoryService;

        public CreateRecipeCategoryHandler(IRecipeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task HandleAsync(RecipeCategoryCreateDto command)
            => await _categoryService.AddAsync(command);
    }
}
