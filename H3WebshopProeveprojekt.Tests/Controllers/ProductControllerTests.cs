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
    }
}
