using CookBook.Core.Domain;
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
        Task<IEnumerable<RecipeDto>> GetAsync(RecipeCategory recipeCategory);
        Task<RecipeDto> GetAsync(Guid id);
        Task AddAsync(RecipeCreateDto recipeDto);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}
