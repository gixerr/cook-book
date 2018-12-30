using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Api.EntityFramework;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.Repositories.EntityFramework
{
    public class EntityFrameworkRecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly CookBookDbContext _context;

        public EntityFrameworkRecipeCategoryRepository(CookBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeCategory>> GetAllAsync()
            => await _context.RecipeCategories.ToListAsync();

        public async Task<RecipeCategory> GetAsync(Guid id)
            => await _context.RecipeCategories.FindAsync(id);

        public async Task<RecipeCategory> GetAsync(string name)
            => await _context.RecipeCategories.SingleOrDefaultAsync(x
                   => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        public async Task AddAsync(RecipeCategory recipeCategory)
        {
            await _context.RecipeCategories.AddAsync(recipeCategory);
            await _context.SaveChangesAsync();    
        }

        public async Task UpdateAsync(RecipeCategory category)
            => await _context.SaveChangesAsync();

        public async Task RemoveAsync(RecipeCategory category)
        {
            _context.RecipeCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
