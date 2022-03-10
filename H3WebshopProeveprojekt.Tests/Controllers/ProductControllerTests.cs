using H3WebshopProeveprojekt.Api.Controllers;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3WebshopProeveprojekt.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockproductService = new();
        private readonly ProductController _productController;

        public ProductControllerTests()
        {
            _productController = new(_mockproductService.Object);
        }

        [Fact]
        public async void GetAllProducts_ShouldReturnStatusCode200_WhenProductsExists()
        {
            //Arrange
            int id = 1;
            List<ProductResponse> products = new();
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

            _mockproductService
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(products);
            //Act
            var result = await _productController.GetAllProducts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetAllProducts_ShouldReturnStatusCode204_WhenNoProductsExists()
        {
            //Arrange
            List<ProductResponse> products = new();
            
            _mockproductService
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(products);
            //Act
            var result = await _productController.GetAllProducts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetAllProducts_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockproductService
                .Setup(x => x.GetAllProducts())
                .ReturnsAsync(() => throw new Exception("This is another exception caused by the invasion of Ukraine. Vladimir Putin ???? - 2022"));
            //Act
            var result = await _productController.GetAllProducts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetProductById_ShouldReturnStatusCode200_WhenProductExists()
        {
            //Arrange
            int id = 1;
            ProductResponse product = new()
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
            _mockproductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(product);
            //Act
            var result = await _productController.GetProductById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetProductById_ShouldReturnStatusCode404_WheNonProductExists()
        {
            //Arrange
            int id = 1;
            _mockproductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _productController.GetProductById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetProductById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int id = 1;
            _mockproductService
                .Setup(x => x.GetProductById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is another exception caused by the invasion of Ukraine. Vladimir Putin ???? - 2022"));
            //Act
            var result = await _productController.GetProductById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

    }
}
