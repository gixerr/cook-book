using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;

namespace CookBook.Core.Repositories
{
    public interface IRecipeCategoryRepository : IRepository
    {
        Task<IEnumerable<RecipeCategory>> GetAllAsync();
        Task<RecipeCategory> GetAsync(Guid id);
        Task<RecipeCategory> GetAsync(string name);
        Task AddAsync(RecipeCategory recipeCategory);
        Task UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);
    }
}