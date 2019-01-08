using CookBook.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllAsync();
        Task<IEnumerable<RecipeDto>> GetAsync(string name);
        Task<IEnumerable<RecipeDto>> GetAsync(RecipeCategoryDto recipeCategoryDto);
        Task<RecipeDto> GetAsync(Guid id);
        Task AddAsync(RecipeCreateDto recipeDto);
        Task UpdateAsync(RecipeUpdateDto recipeUpdateDto);
        Task RemoveAsync(Guid id);
        Task AddIngredientAsync(RecipeIngredientAddDto recipeIngredientDto);
        Task RemoveIngredientAsync(RecipeIngredientRemoveDto recipeIngredientDto);
    }
}
