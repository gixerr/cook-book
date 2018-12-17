using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.EntityFramework
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions<CookBookDbContext> options) : base(options)
        {
        }
    }
}
