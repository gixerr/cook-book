using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;

namespace CookBook.Core.Repositories
{
    public interface IRecipeRepository : IRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<IEnumerable<Recipe>> GetAsync(string name);
        Task<IEnumerable<Recipe>> GetAsync(RecipeCategory recipeCategory);
        Task<Recipe> GetAsync(Guid id);
        Task AddAsync(Recipe recipe);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}