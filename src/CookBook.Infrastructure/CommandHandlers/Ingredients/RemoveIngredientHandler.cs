using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Ingredients
{
    public class RemoveIngredientHandler : ICommandHandler<IngredientRemoveDto>
    {
        private readonly IIngredientService _service;

        public RemoveIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task HandleAsync(IngredientRemoveDto command) 
            => await _service.RemoveAsync(command.Id);
    }
}
