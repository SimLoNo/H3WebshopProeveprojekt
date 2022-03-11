using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3WebshopProeveprojekt.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly DbContextOptions<H3WebshopProeveprojektContext> _options;
        private readonly H3WebshopProeveprojektContext _context;
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<H3WebshopProeveprojektContext>()
                .UseInMemoryDatabase(databaseName: "H3WebshopProeveprojektProducts")
                .Options;

            _context = new(_options);

            _productRepository = new(_context);
        }

        [Fact]
        public async void GetAllProducts_ShouldReturnListOfProducts_WhenProductsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            int id =1;

            _context.Category.Add(
            new()
            {
                Id = id,
                CategoryName = "Trousers"
            });

            _context.Product.Add(
            new()
            {
                Id = id,
                Name = "JeansA",
                Price = 1234,
                DiscountPercentage = 0,
                CategoryId = id
            });
            _context.Product.Add(
            new()
            {
                Id = id + 1,
                Name = "JeansB",
                Price = 4321,
                DiscountPercentage = 0,
                CategoryId = id
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _productRepository.GetAllProducts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Product>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllProducts_ShouldReturnEmptyListOfProducts_WhenNoProductsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _productRepository.GetAllProducts();
            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetProductById_ShouldReturnNull_WhenNoProductExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _productRepository.GetProductById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetProductById_ShouldReturnProduct_WhenProductExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(
            new()
            {
                Id = id,
                CategoryName = "Trousers"
            });
            _context.Product.Add(new()
            {
                Id = id,
                Name = "JeansA",
                Price = 1234,
                DiscountPercentage = 0,
                CategoryId = id
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _productRepository.GetProductById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void InsertProduct_ShouldReturnProductWithCategory_WhenProductIsInserted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();

            _context.Category.Add(
            new()
            {
                Id = id,
                CategoryName = "Trousers"
            });

            await _context.SaveChangesAsync();

            Product product = new()
            {
                Name = "JeansA",
                Price = 1234,
                DiscountPercentage = 0,
                CategoryId = id
            };
            //Act
            var result = await _productRepository.InsertProduct(product);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Category);
            Assert.IsType<Product>(result);
            Assert.Equal(id,result.Category.Id);
        }

        [Fact]
        public async void DeleteProduct_ShouldReturnNull_WhenTheProductDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            int id = 1;


            //Act
            var result = await _productRepository.DeleteProduct(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteProduct_ShouldReturnProduct_WhenTheProductIsExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.Product.Add(new()
            {
                Id = id,
                Name = "War crime",
                Price = 10.10f,
                DiscountPercentage = 0,
                CategoryId = id
            });
            _context.Category.Add(new()
            {
                Id = id,
                CategoryName = "Putin"
            });
            await _context.SaveChangesAsync();



            //Act
            var result = await _productRepository.DeleteProduct(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(id, result.Id);
        }
    }
}
