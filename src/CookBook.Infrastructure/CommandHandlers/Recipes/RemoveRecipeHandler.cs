using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Recipes
{
    public class RemoveRecipeHandler : ICommandHandler<RecipeRemoveDto>
    {
        private readonly IRecipeService _service;

        public RemoveRecipeHandler(IRecipeService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RecipeRemoveDto command)
            => await _service.RemoveAsync(command.Id);
    }
}
