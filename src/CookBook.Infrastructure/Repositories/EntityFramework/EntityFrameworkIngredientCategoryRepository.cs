using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Core.Domain;
using CookBook.Core.Repositories;
using CookBook.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.Repositories.EntityFramework
{
    public class EntityFrameworkIngredientCategoryRepository : IIngredientCategoryRepository
    {
        private readonly CookBookDbContext _context;

        public EntityFrameworkIngredientCategoryRepository(CookBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredientCategory>> GetAllAsync()
            => await _context.IngredientCategories.ToListAsync();

        public async Task<IngredientCategory> GetAsync(Guid id)
            => await _context.IngredientCategories.FindAsync(id);

        public async Task<IngredientCategory> GetAsync(string name)
            => await _context.IngredientCategories.SingleOrDefaultAsync(x
                   => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

        public async Task AddAsync(IngredientCategory ingredientCategory)
        {
            await _context.IngredientCategories.AddAsync(ingredientCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IngredientCategory ingredientCategory) 
            => await _context.SaveChangesAsync();

        public async Task RemoveAsync(IngredientCategory ingredientCategory)
        {
            _context.IngredientCategories.Remove(ingredientCategory);
            await _context.SaveChangesAsync();
        }
    }
}
