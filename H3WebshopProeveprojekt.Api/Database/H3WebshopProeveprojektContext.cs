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
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new()
                {
                    Id = 1,
                    CategoryName = "Trousers"
                },
                new()
                {
                    Id = 2,
                    CategoryName = "Shirts"
                });

            modelBuilder.Entity<Product>().HasData(
                new()
                {
                    Id = 1,
                    Name = "Jeans",
                    Price = 400,
                    DiscountPercentage = 0,
                    CategoryId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Woolies",
                    Price = 300,
                    DiscountPercentage = 0,
                    CategoryId = 1
                },
                new()
                {
                    Id = 3,
                    Name = "Serena shirt",
                    Price = 600,
                    DiscountPercentage = 0,
                    CategoryId = 2
                },
                new()
                {
                    Id = 4,
                    Name = "Tshirt",
                    Price = 200,
                    DiscountPercentage = 0,
                    CategoryId = 2
                });
        }
    }
}
