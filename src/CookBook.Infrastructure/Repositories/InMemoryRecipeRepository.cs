using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;

namespace CookBook.Infrastructure.Repositories
{
    public class InMemoryRecipeRepository : IRecipeRepository
    {
        private static readonly ISet<Recipe> Recipes = new HashSet<Recipe>();

        public async Task<IEnumerable<Recipe>> GetAllAsync()
            => await Task.FromResult(Recipes);

        public async Task<IEnumerable<Recipe>> GetAsync(string name)
            => await Task.FromResult(
                   Recipes.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)));

        public async Task<IEnumerable<Recipe>> GetAsync(RecipeCategory recipeCategory)
            => await Task.FromResult(Recipes.Where(x => x.Category.Equals(recipeCategory)));

        public async Task<Recipe> GetAsync(Guid id)
            => await Task.FromResult(Recipes.SingleOrDefault(x => x.Id.Equals(id)));

        public async Task AddAsync(Recipe recipe)
            => await Task.FromResult(Recipes.Add(recipe));

        public async Task UpdateAsync(Guid id)
            => await Task.CompletedTask;

        public async Task RemoveAsync(Guid id)
            => Recipes.Remove(await GetAsync(id));
    }
}
