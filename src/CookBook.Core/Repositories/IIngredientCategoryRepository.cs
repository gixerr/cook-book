using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;

namespace CookBook.Core.Repositories
{
    public interface IIngredientCategoryRepository
    {
        Task<IEnumerable<IngredientCategory>> GetAllAsync();
        Task<IngredientCategory> GetAsync(Guid id);
        Task<IngredientCategory> GetAsync(string name);
        Task AddAsync(IngredientCategory ingredientCategory);
        Task UpdateAsync(Guid id);
        Task Delete(Guid id);
    }
}