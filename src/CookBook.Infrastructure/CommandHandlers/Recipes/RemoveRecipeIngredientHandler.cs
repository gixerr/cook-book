using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Recipes
{
    public class RemoveRecipeIngredientHandler : ICommandHandler<RecipeIngredientRemoveDto>
    {
        private readonly IRecipeService _service;

        public RemoveRecipeIngredientHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RecipeIngredientRemoveDto command) 
            => await _service.RemoveIngredientAsync(command);
    }
}
