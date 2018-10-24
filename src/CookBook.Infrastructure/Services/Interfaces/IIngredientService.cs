using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IIngredientService
    {
         Task<IEnumerable<IngredientDto>> GetAllAsync();
         Task<IEnumerable<IngredientDto>> GetAsync(string name);
         Task<IngredientDto> GetAsync(Guid id);
         Task AddAsync(IngredientCreateDto ingredientDto);
         Task UpdateAsync(Guid id);
         Task RemoveAsync(Guid id);
    }
}