using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Ingredients
{
    public class UpdateIngredientHandler : ICommandHandler<IngredientUpdateDto>
    {
        private readonly IIngredientService _service;

        public UpdateIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task HandleAsync(IngredientUpdateDto command) 
            => await _service.UpdateAsync(command);
    }
}
