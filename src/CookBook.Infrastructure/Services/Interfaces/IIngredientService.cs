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
        Task<IEnumerable<IngredientDto>> GetAsync(IngredientCategory ingredientCategory);
        Task<IngredientDto> GetAsync(Guid id);
        Task AddAsync(IngredientCreateDto ingredientDto);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}
