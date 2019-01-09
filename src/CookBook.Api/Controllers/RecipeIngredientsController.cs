using System.Threading.Tasks;
using CookBook.Infrastructure.Commands.Interfaces;
using CookBook.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    public class RecipeIngredientsController : BaseController
    {
        public RecipeIngredientsController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(RecipeIngredientAddDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
        
        [HttpDelete]
        public async Task<ActionResult> Remove(RecipeIngredientRemoveDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
