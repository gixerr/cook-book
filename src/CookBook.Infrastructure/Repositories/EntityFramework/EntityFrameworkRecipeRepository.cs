using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Api.EntityFramework;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.Repositories.EntityFramework
{
    public class EntityFrameworkRecipeRepository : IRecipeRepository
    {
        private readonly CookBookDbContext _context;

        public EntityFrameworkRecipeRepository(CookBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
            => await _context.Recipes.ToListAsync();

        public async Task<IEnumerable<Recipe>> GetAsync(string name)
            => await _context.Recipes.Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                             .ToListAsync();

        public async Task<IEnumerable<Recipe>> GetAsync(RecipeCategory recipeCategory)
            => await _context.Recipes.Where(x => x.Category.Equals(recipeCategory)).ToListAsync();

        public async Task<Recipe> GetAsync(Guid id)
            => await _context.Recipes.FindAsync(id);

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe recipe)
            => await _context.SaveChangesAsync();

        public async Task RemoveAsync(Recipe recipe)
        {
            _context.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
