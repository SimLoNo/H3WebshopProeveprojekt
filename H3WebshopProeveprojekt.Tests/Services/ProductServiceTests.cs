﻿using H3WebshopProeveprojekt.Api.Database.Entities;
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
    }
}
