using System;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Recipes
{
    public class UpdateRecipeHandler : ICommandHandler<RecipeUpdateDto>
    {
        private readonly IRecipeService _service;

        public UpdateRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RecipeUpdateDto command)
        {
            var recipes = await _service.GetAsync(command.Name);
            var recipeToUpdateId = recipes.Single(x => x.Category.Name.Equals(command.CategoryName,
                StringComparison.OrdinalIgnoreCase)).Id;

            await _service.UpdateAsync(recipeToUpdateId, command);
        }
    }
}
