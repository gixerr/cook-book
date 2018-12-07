using System;
using System.Threading.Tasks;
using CookBook.Infrastructure.Commands.Interfaces;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    public class IngredientCategoriesController : BaseController
    {
        private readonly IIngredientCategoryService _categoryService;

        public IngredientCategoriesController(ICommandDispatcher commandDispatcher,
            IIngredientCategoryService categoryService) : base(commandDispatcher)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> Read()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> Read(Guid id)
        {
            var category = await _categoryService.GetAsync(id);

            return Ok(category);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> Read(string name)
        {
            var category = await _categoryService.GetAsync(name);

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(IngredientCategoryCreateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"api/ingredientcategories/name/{command.Name}", null);
        }

        [HttpPut]
        public async Task<ActionResult> Update(IngredientCategoryUpdateDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(IngredientCategoryRemoveDto command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
        

    }
}
