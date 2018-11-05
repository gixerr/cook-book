using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;

namespace CookBook.Infrastructure.Repositories
{
    public class InMemoryIngredientCategoryRepository : IIngredientCategoryRepository
    {
        private static readonly ISet<IngredientCategory> Categories = new HashSet<IngredientCategory>();

        public async Task<IEnumerable<IngredientCategory>> GetAllAsync()
            => await Task.FromResult(Categories);

        public async Task<IngredientCategory> GetAsync(Guid id)
            => await Task.FromResult(Categories.SingleOrDefault(x => x.Id.Equals(id)));

        public async Task<IngredientCategory> GetAsync(string name)
            => await Task.FromResult(Categories.SingleOrDefault(x =>
                x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));

        public async Task AddAsync(IngredientCategory ingredientCategory)
            => await Task.FromResult(Categories.Add(ingredientCategory));

        public async Task UpdateAsync(IngredientCategory ingredientCategory)
            => await Task.CompletedTask;

        public async Task RemoveAsync(Guid id)
            => Categories.Remove(await GetAsync(id));
    }
}