using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetAllAsync();
        Task<IEnumerable<RecipeDto>> GetAsync(string name);
        Task<RecipeDto> GetAsync(Guid id);
        Task AddAsync(RecipeCreateDto recipeDto);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);

    }
}