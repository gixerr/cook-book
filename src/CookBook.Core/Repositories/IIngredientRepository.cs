using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;

namespace CookBook.Core.Repositories
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<IEnumerable<Ingredient>> GetAsync(string name);
        Task<IEnumerable<Ingredient>> GetAsync(IngredientCategory ingredientCategory);
        Task<Ingredient> GetAsync(Guid id);
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}