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
        Task AddAsync(RecipeCategory category);
        Task UpdateAsync(RecipeCategory category);
        Task RemoveAsync(RecipeCategory category);
    }
}
