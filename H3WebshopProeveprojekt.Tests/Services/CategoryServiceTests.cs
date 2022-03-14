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
    public class CategoryServiceTests
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository = new();

        public CategoryServiceTests()
        {
            _categoryService = new(_mockCategoryRepository.Object);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnListOfCategorieResponse_WhenCategoriesExists()
        {
            //Arrange
            List<Category> categories = new();
            categories.Add(new()
            {
                Id = 1,
                CategoryName = "War Criminal"
            });
            categories.Add(new()
            {
                Id = 2,
                CategoryName = "Almost every other nation than Russia"
            });

            _mockCategoryRepository
                .Setup(x => x.GetAllCategories())
                .ReturnsAsync(categories);
            //Act
            var result = await _categoryService.GetAllCategories();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<CategoryResponse>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnEmptyListOfCategoryResponse_WhenNoCategoriesExists()
        {
            //Arrange
            List<Category> categories = new();
            _mockCategoryRepository
                .Setup(x => x.GetAllCategories())
                .ReturnsAsync(categories);
            //Act
            var result = await _categoryService.GetAllCategories();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Category>>(result);
            Assert.Empty(result);
        }
    }
}
