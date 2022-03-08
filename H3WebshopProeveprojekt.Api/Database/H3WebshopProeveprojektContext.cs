using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace H3WebshopProeveprojekt.Api.Database
{
    public class H3WebshopProeveprojektContext : DbContext
    {
        public H3WebshopProeveprojektContext(){}

        public H3WebshopProeveprojektContext(DbContextOptions<H3WebshopProeveprojektContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
