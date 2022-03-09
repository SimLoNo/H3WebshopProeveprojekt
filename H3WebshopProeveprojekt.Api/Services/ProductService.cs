using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>>GetAllProducts();
        Task<ProductResponse> GetProductById(int id);
        Task<ProductResponse> InsertProduct(ProductRequest productRequest);
        Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest);
        Task<ProductResponse> DeleteProduct(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task<ProductResponse> DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await _repository.GetAllProducts();

            return products.Select(product => MapProductToProductResponse(product)).ToList();
        }

        public Task<ProductResponse> GetProductById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductResponse> InsertProduct(ProductRequest productRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest)
        {
            throw new System.NotImplementedException();
        }

        private static ProductResponse MapProductToProductResponse(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DiscountPercentage = product.DiscountPercentage,
                CategoryId = product.CategoryId,
                Category = new Category
                {
                    Id = product.Category.Id,
                    CategoryName = product.Category.CategoryName
                }
            };
        }
    }
}
