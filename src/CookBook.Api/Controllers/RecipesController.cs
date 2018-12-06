using System;
using System.Threading.Tasks;
using CookBook.Infrastructure.Commands.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    public class RecipesController : BaseController
    {
        private readonly IRecipeService _service;

        public RecipesController(ICommandDispatcher commandDispatcher, IRecipeService service) : base(commandDispatcher)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult> Read()
        {
            var recipes = await _service.GetAllAsync();

            return Ok(recipes);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> Read(Guid id)
        {
            var recipe = _service.GetAsync(id);

            return Ok(recipe);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Read(string name)
        {
            var recipes = _service.GetAsync(name);

            return Ok(recipes);
        }

        [HttpGet]
        public async Task<ActionResult> Read(RecipeCategoryDto categoryDto)
        {
            var recipes = await _service.GetAsync(categoryDto);

            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RecipeCreateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"api/recipes/{command.Name}", null);
        }

        [HttpPut]
        public async Task<ActionResult> Update(RecipeUpdateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(RecipeRemoveDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
