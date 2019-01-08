using CookBook.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.EntityFramework
{
    public class CookBookDbContext : DbContext
    {

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options) : base(options)
        {
        }
    }
}
