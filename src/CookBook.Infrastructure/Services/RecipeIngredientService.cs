using System.Threading.Tasks;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.Dto;
using CookBook.Infrastructure.Repositories.Extensions;
using CookBook.Infrastructure.Services.Interfaces;

namespace CookBook.Infrastructure.Services
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipeIngredientService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task AddIngredientAsync(RecipeIngredientAddDto recipeIngredientDto)
            => await _recipeRepository.AddIngredientOrThrowAsync(_ingredientRepository, recipeIngredientDto);

        public async Task RemoveIngredientAsync(RecipeIngredientRemoveDto recipeIngredientDto) 
            => await _recipeRepository.RemoveIngredientOrThrowAsync(recipeIngredientDto);
    }
}
