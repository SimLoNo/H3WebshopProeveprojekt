using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using H3WebshopProeveprojekt.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3WebshopProeveprojekt.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<IProductRepository> _mockProductRepository = new();

        public ProductServiceTests()
        {
            _productService = new(_mockProductRepository.Object);
        }

        [Fact]
        public async void GetAllProducts_ShouldReturnListProductResponse_WhenProductsExists()
        {
            //Arrange
            int id = 1;
            List<Product> products = new();

            products.Add(
                new()
                {
                    Id = id,
                    Name = "JeansA",
                    Price = 1234,
                    DiscountPercentage = 0,
                    CategoryId = id,
                    Category = new()
                    {
                        Id = id,
                        CategoryName = "Trousers"
                    }
                });
            products.Add(
                new()
                {
                    Id = id + 1,
                    Name = "JeansB",
                    Price = 4321,
                    DiscountPercentage = 0,
                    CategoryId = id,
                    Category = new()
                    {
                        Id = id,
                        CategoryName = "Trousers"
                    }
                });

            _mockProductRepository
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(products);
                
            //Act
            var result = await _productService.GetAllProducts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProductResponse>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllProducts_ShouldReturnEmptyListProductResponse_WhenProductsExists()
        {
            //Arrange
            List<Product> products = new();
            
            _mockProductRepository
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(products);

            //Act
            var result = await _productService.GetAllProducts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProductResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetProductById_ShouldNull_WhenNoProductExists()
        {
            //Arrange
            int id = 1;
            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _productService.GetProductById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetProductById_ShouldReturnProduct_WhenProductExists()
        {
            //Arrange
            int id = 1;
            Product product = new()
            {
                Id = id,
                Name = "JeansA",
                Price = 1234,
                DiscountPercentage = 0,
                CategoryId = id,
                Category = new()
                {
                    Id = id,
                    CategoryName = "Trousers"
                }

            };

            _mockProductRepository
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(product);

            //Act
            var result = await _productService.GetProductById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void InsertProduct_ShoulReturnProductResponse_WhenProductIsInserted()
        {
            //Arrange
            int id = 1;
            ProductRequest productRequest = new()
            {

                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id,
            };
            Product product = new()
            {
                Id = id,
                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id,
                Category = new()
                {
                    Id = id,
                    CategoryName = "War criminal"
                }
            };
            _mockProductRepository
                .Setup(x => x.InsertProduct(It.IsAny<Product>()))
                .ReturnsAsync(product);
            //Act
            var result = await _productService.InsertProduct(productRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(id,result.Id);
        }

        [Fact]
        public async void InsertProduct_ShoulReturnNull_WhenNoProductIsInserted()
        {
            //Arrange
            int id = 1;
            ProductRequest productRequest = new()
            {

                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id,
            };
            _mockProductRepository
                .Setup(x => x.InsertProduct(It.IsAny<Product>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _productService.InsertProduct(productRequest);
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async void UpdateProduct_ShouldReturnNull_WhenNoProductIsUpdated()
        {
            //Arrange
            int id = 1;
            ProductRequest productRequest = new()
            {

                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id
            };
            _mockProductRepository
                .Setup(x => x.UpdateProduct(It.IsAny<int>(),It.IsAny<Product>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _productService.UpdateProduct(id,productRequest);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateProduct_ShouldReturnProductResponse_WhenProductIsUpdated()
        {
            //Arrange
            int id = 1;
            ProductRequest productRequest = new()
            {
                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id
            };

            Product product = new()
            {
                Id = id,
                Name = "Skin of Putin",
                Price = 10.00f,
                DiscountPercentage = 0,
                CategoryId = id,
                Category = new()
                {
                    Id = id,
                    CategoryName = "War criminal"
                }
            };

            _mockProductRepository
                .Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>()))
                .ReturnsAsync(product);
            //Act
            var result = await _productService.UpdateProduct(id,productRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void DeleteProduct_ShouldReturnProductResponse_WhenProductIsDeleted()
        {
            //Arrange
            int id = 1;
            Product product = new()
            {
                Id = id,
                Name = "War crime",
                Price = 10.10f,
                DiscountPercentage = 0,
                CategoryId = id,
                Category = new()
                {
                    Id = id,
                    CategoryName= "Putin"
                }
            };
            _mockProductRepository
                .Setup(x => x.DeleteProduct(It.IsAny<int>()))
                .ReturnsAsync(product);
            //Act
            var result = await _productService.DeleteProduct(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductResponse>(result);
            Assert.Equal(id,result.Id);
        }

        [Fact]
        public async void DeleteProduct_ShouldReturnNull_WhenNoProductIsDeleted()
        {
            //Arrange
            int id = 1;

            _mockProductRepository
                .Setup(x => x.DeleteProduct(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _productService.DeleteProduct(id);
            //Assert
            Assert.Null(result);
        }
    }
}
