using System.Threading.Tasks;
using CookBook.Infrastructure.CommandHandlers.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.CommandHandlers.Ingredients
{
    public class CreateIngredientHandler : ICommandHandler<IngredientCreateDto>
    {
        private readonly IIngredientService _service;

        public CreateIngredientHandler(IIngredientService service)
        {
            _service = service;
        }

        public async Task HandleAsync(IngredientCreateDto command) 
            => await _service.AddAsync(command);
    }
}
