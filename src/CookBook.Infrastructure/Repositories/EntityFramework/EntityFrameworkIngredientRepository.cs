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
    public class EntityFrameworkIngredientRepository : IIngredientRepository
    {
        private readonly CookBookDbContext _context;

        public EntityFrameworkIngredientRepository(CookBookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
            => await _context.Ingredients.Include(x => x.Category)
                                         .ToListAsync();

        public async Task<IEnumerable<Ingredient>> GetAsync(string name)
            => await _context.Ingredients.Include(x => x.Category)
                                         .Where(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                                         .ToListAsync();

        public async Task<IEnumerable<Ingredient>> GetAsync(IngredientCategory ingredientCategory)
            => await _context.Ingredients.Where(x => x.Category.Equals(ingredientCategory))
                                         .ToListAsync();

        public async Task<Ingredient> GetAsync(Guid id)
            => await _context.Ingredients.Include(x => x.Category)
                                         .SingleOrDefaultAsync(x => x.Id.Equals(id));

        public async Task AddAsync(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ingredient ingredient)
            => await _context.SaveChangesAsync();

        public async Task RemoveAsync(Ingredient ingredient)
        {
            _context.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
