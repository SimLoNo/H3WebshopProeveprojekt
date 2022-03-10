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
        Task<Product> GetProductById(int productId);
        Task<Product> InsertProduct(Product product);
        Task<Product> UpdateProduct(int productId,Product product);
        Task<Product> DeleteProduct(int productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly H3WebshopProeveprojektContext _context;

        public ProductRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }

        public Task<Product> DeleteProductById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<Product> InsertProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            int categoryId= product.CategoryId;
            product.Category = await _context.Category.FirstOrDefaultAsync(category => category.Id == categoryId);
            return product;
        }

        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            Product updateProduct = await _context.Product
                .FirstOrDefaultAsync(p => p.Id == productId);
            if (updateProduct != null)
            {
                updateProduct.Name = product.Name;
                updateProduct.Price = product.Price;
                updateProduct.DiscountPercentage = product.DiscountPercentage;
                updateProduct.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
                updateProduct.Category = product.Category;
            }
                return updateProduct;
        }

        public Task<Product> DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
