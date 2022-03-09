using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
    public class ProductRepository : IProductRepository
    {
        private readonly H3WebshopProeveprojektContext _context;

        public ProductRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
