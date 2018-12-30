using Microsoft.EntityFrameworkCore;
using CookBook.Core.Domain;

namespace CookBook.Api.EntityFramework
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
    }
}