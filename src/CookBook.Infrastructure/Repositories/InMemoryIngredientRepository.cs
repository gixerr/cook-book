using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;

namespace CookBook.Infrastructure.Repositories
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private static readonly ISet<Ingredient> Ingredients = new HashSet<Ingredient>();

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
            => await Task.FromResult(Ingredients);

        public async Task<IEnumerable<Ingredient>> GetAsync(string name)
            => await Task.FromResult(Ingredients.Where(x => x.Name.ToLowerInvariant().Equals(name.ToLowerInvariant())));

        public async Task<IEnumerable<Ingredient>> GetAsync(IngredientCategory ingredientCategory)
            => await Task.FromResult(Ingredients.Where(x => x.Category.Equals(ingredientCategory)));

        public async Task<Ingredient> GetAsync(Guid id)
            => await Task.FromResult(Ingredients.SingleOrDefault(x => x.Id.Equals(id)));

        public async Task AddAsync(Ingredient ingredient)
            => await Task.FromResult(Ingredients.Add(ingredient));

        public async Task UpdateAsync(Guid id)
            => await Task.CompletedTask;

        public async Task RemoveAsync(Guid id)
            => Ingredients.Remove(await GetAsync(id));
    }
}