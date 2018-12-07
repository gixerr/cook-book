using System;
using System.Threading.Tasks;
using CookBook.Infrastructure.Commands.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    public class IngredientsController : BaseController
    {
        private readonly IIngredientService _service;

        public IngredientsController(ICommandDispatcher commandDispatcher, IIngredientService service)
            : base(commandDispatcher)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Read()
        {
            var ingredients = await _service.GetAllAsync();

            return Ok(ingredients);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Read(string name)
        {
            var ingredients = await _service.GetAsync(name);

            return Ok(ingredients);
        }

        [HttpGet]
        public async Task<ActionResult> Read(IngredientCategoryDto ingredientDto)
        {
            var ingredients = await _service.GetAsync(ingredientDto);

            return Ok(ingredients);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> Read(Guid id)
        {
            var ingredient = await _service.GetAsync(id);

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IngredientCreateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"api/ingredients/{command.Name}", null);
        }

        [HttpPut]
        public async Task<ActionResult> Update(IngredientUpdateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(IngredientRemoveDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
