using H3WebshopProeveprojekt.Api.DTO;
using System.Collections.Generic;
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
        public Task<ProductResponse> DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<ProductResponse> productsResponse = new()
            {
                new()
                {
                    Id = 1,
                    Name = "Ukrainer",
                    Price = 700,
                    DiscountPercentage = 0,
                    Category = "shirt"
                },
                new()
                {
                    Id = 1,
                    Name = "Ukrainer",
                    Price = 700,
                    DiscountPercentage = 0,
                    Category = "shirt"
                }
            };

            return productsResponse;
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
    }
}
