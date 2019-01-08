using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Recipes
{
    public class AddRecipeIngredientHandler : ICommandHandler<RecipeIngredientAddDto>
    {
        private readonly IRecipeService _service;

        public AddRecipeIngredientHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RecipeIngredientAddDto command) 
            => await _service.AddIngredientAsync(command);
    }
}
