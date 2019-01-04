using CookBook.Api.EntityFramework;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            => await _context.Recipes.Include(x => x.Category)
                                     .ToListAsync();

        public async Task<IEnumerable<Recipe>> GetAsync(string name) 
            => await _context.Recipes.Include(x => x.Category)
                                     .Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                                     .ToListAsync();

        public async Task<IEnumerable<Recipe>> GetAsync(RecipeCategory recipeCategory) 
            => await _context.Recipes.Include(x => x.Category)
                                     .Where(x => x.Category.Equals(recipeCategory))
                                     .ToListAsync();

        public async Task<Recipe> GetAsync(Guid id) 
            => await _context.Recipes.Include(x => x.Category)
                                     .SingleOrDefaultAsync(x => x.Id.Equals(id));

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
