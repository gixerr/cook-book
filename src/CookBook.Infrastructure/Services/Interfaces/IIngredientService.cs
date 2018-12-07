using CookBook.Core.Domain;
using CookBook.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync();
        Task<IEnumerable<IngredientDto>> GetAsync(string name);
        Task<IEnumerable<IngredientDto>> GetAsync(IngredientCategoryDto ingredientCategoryDto);
        Task<IngredientDto> GetAsync(Guid id);
        Task AddAsync(IngredientCreateDto ingredientDto);
        Task UpdateAsync(IngredientUpdateDto ingredientUpdateDto);
        Task RemoveAsync(Guid id);
    }
}
