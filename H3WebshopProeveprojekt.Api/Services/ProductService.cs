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
        public async Task<ProductResponse> DeleteProduct(int id)
        {
            Product product = await _repository.DeleteProduct(id);
            if (product != null)
            {
                return MapProductToProductResponse(product);
            }
            return null;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await _repository.GetAllProducts();
            if (products != null)
            {
                return products.Select(product => MapProductToProductResponse(product)).ToList();
            }
            return null;
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            Product product = await _repository.GetProductById(id);
            if (product != null)
            {
                return MapProductToProductResponse(product);

            }
            return null;
        }

        public async Task<ProductResponse> InsertProduct(ProductRequest productRequest)
        {
            Product product = MapProductRequestToProduct(productRequest);
            Product insertedProduct = await _repository.InsertProduct(product);
            if (insertedProduct != null)
            {
                return MapProductToProductResponse(insertedProduct);
            }
            return null;
        }

        public async Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest)
        {
            Product product = MapProductRequestToProduct(productRequest);
            Product updatedProduct = await _repository.UpdateProduct(id, product);
            if (updatedProduct != null)
            {
                return MapProductToProductResponse(updatedProduct);
            }
            return null;
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
                Category = new()
                {
                    Id = product.Category.Id,
                    CategoryName = product.Category.CategoryName
                }
            };
        }

        private static Product MapProductRequestToProduct(ProductRequest productRequest)
        {
            return new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                DiscountPercentage = productRequest.DiscountPercentage,
                CategoryId = productRequest.CategoryId
            };
        }
    }
}
