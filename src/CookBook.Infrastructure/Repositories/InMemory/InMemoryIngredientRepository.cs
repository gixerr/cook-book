using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;

namespace CookBook.Infrastructure.Repositories.InMemory
{
    public class InMemoryIngredientRepository : IIngredientRepository
    {
        private static readonly ISet<Ingredient> Ingredients = new HashSet<Ingredient>();

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
            => await Task.FromResult(Ingredients);

        public async Task<IEnumerable<Ingredient>> GetAsync(string name)
            => await Task.FromResult(Ingredients.Where(x
                   => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));

        public async Task<IEnumerable<Ingredient>> GetAsync(IngredientCategory ingredientCategory)
            => await Task.FromResult(Ingredients.Where(x => x.Category.Equals(ingredientCategory)));

        public async Task<Ingredient> GetAsync(Guid id)
            => await Task.FromResult(Ingredients.SingleOrDefault(x => x.Id.Equals(id)));

        public async Task AddAsync(Ingredient ingredient)
            => await Task.FromResult(Ingredients.Add(ingredient));

        public async Task UpdateAsync(Ingredient ingredient)
            => await Task.CompletedTask;

        public async Task RemoveAsync(Ingredient ingredient) 
            => await Task.FromResult(Ingredients.Remove(ingredient));
    }
}
