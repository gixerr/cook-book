using CookBook.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Api.EntityFramework
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
