using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3WebshopProeveprojekt.Tests.Repositories
{
    public class CategoryRepositoryTests
    {
        private readonly DbContextOptions<H3WebshopProeveprojektContext> _options;
        private readonly H3WebshopProeveprojektContext _context;
        private readonly CategoryRepository _categoryRepository;
        public CategoryRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<H3WebshopProeveprojektContext>()
                .UseInMemoryDatabase(databaseName: "H3WebshopProeveprojektCategories")
                .Options;

            _context = new(_options);

            _categoryRepository = new(_context);
        }
        [Fact]
        public async void GetAllCategories_ShouldReturnListOfCategories_WHenCategoriesExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new()
            {
                Id = 1,
                CategoryName = "shirt"
            });

            _context.Category.Add(new()
            {
                Id = 2,
                CategoryName = "War criminal"
            });
            await _context.SaveChangesAsync();

            //Act
            var result = await _categoryRepository.GetAllCategories();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnEmptyListOfCategories_WhenNoCategoriesExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _categoryRepository.GetAllCategories();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnCategory_WhenTheCategoryExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new()
            {
                Id = id,
                CategoryName = "War criminal"
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _categoryRepository.GetCategoryById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnNull_WhenTheCategoryDoesNotExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _categoryRepository.GetCategoryById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnCategory_WhenCategoryIsInserted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            int id = 1;
            Category category = new()
            {
                Id=id,
                CategoryName = "War criminal"
            };
            //Act
            var result = await _categoryRepository.InsertNewCategory(category);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(id, result.Id);
        }
        [Fact]
        public async void InsertNewCategory_ShouldRaiseException_WhenCategoryAlreadyExists()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id = id,
                CategoryName = "War criminal"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            
            //Act
            async Task action() => await _categoryRepository.InsertNewCategory(category);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnCategoryWithListOfProduct_WhenCategoryExists()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id = id,
                CategoryName = "Vladimir Putin"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Category.Add(new()
            {
                Id = id,
                CategoryName = "Criminal"
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _categoryRepository.UpdateCategory(id, category);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Category>(result);
            Assert.Equal(id, result.Id);
            Assert.IsType<List<Product>>(result.Products);
            Assert.Empty(result.Products);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnNull_WhenNoCategoryExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            int id = 1;
            Category category = new()
            {
                Id = id,
                CategoryName = "Fuck Putin!"
            };
            //Act
            var result = await _categoryRepository.UpdateCategory(id,category);
            //Assert
            Assert.Null(result);
        }
    }
}
