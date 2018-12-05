using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Recipes
{
    public class CreateRecipeHandler : ICommandHandler<RecipeCreateDto>
    {
        private readonly IRecipeService _service;

        public CreateRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RecipeCreateDto command)
            => await _service.AddAsync(command);
    }
}
