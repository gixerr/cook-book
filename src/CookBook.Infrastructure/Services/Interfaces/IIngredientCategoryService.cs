using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Infrastructure.Dto;

namespace CookBook.Infrastructure.Services.Interfaces
{
    public interface IIngredientCategoryService
    {
         Task<IEnumerable<IngredientCategoryDto>> GetAllAsync();
         Task<IngredientCategoryDto> GetAsync(Guid id);
         Task<IngredientCategoryDto> GetAsync(string name);
         Task AddAsync(IngredientCategoryCreateDto categoryDto);
         Task UpdateAsync(IngredientCategoryUpdateDto categoryDto);
         Task RemoveAsync(Guid id);
    }
}
