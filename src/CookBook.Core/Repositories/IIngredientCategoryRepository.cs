using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;

namespace CookBook.Core.Repositories
{
    public interface IIngredientCategoryRepository : IRepository
    {
        Task<IEnumerable<IngredientCategory>> GetAllAsync();
        Task<IngredientCategory> GetAsync(Guid id);
        Task<IngredientCategory> GetAsync(string name);
        Task AddAsync(IngredientCategory ingredientCategory);
        Task UpdateAsync(IngredientCategory ingredientCategory);
        Task RemoveAsync(IngredientCategory ingredientCategory);
    }
}
