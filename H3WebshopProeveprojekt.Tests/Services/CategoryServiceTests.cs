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
                CategoryName = "War Criminal",
                Products = new List<Product>()
            });
            categories.Add(new()
            {
                Id = 2,
                CategoryName = "Almost every other nation than Russia",
                Products = new List<Product>()
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
            foreach (var category in result)
            {
                Assert.NotNull(category.Products);
            }
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
            Assert.IsType<List<CategoryResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnCategory_WhenTheCategoryExists()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id = id,
                CategoryName = "Putin is a criminal!",
                Products = new List<Product>()
            };

            _mockCategoryRepository
                .Setup(x => x.GetCategoryById(It.IsAny<int>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryService.GetCategoryById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnNull_WhenTheCategoryDoesNotExists()
        {
            //Arrange
            int id = 1;
            _mockCategoryRepository
                .Setup(x => x.GetCategoryById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryService.GetCategoryById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnCategoryResponse_WhenCategoryIsInserted()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id=id,
                CategoryName = "Fuck Putin",
                Products= new List<Product>()
            };
            CategoryRequest categoryRequest = new()
            {
                CategoryName = "Fuck Putin",
            };

            _mockCategoryRepository
                .Setup(x => x.InsertNewCategory(It.IsAny<Category>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryService.InsertNewCategory(categoryRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.NotNull(result.Products);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnNull_WhenCategoryIsInserted()
        {
            //Arrange
            CategoryRequest categoryRequest = new()
            {
                CategoryName = "Fuck Putin",
            };

            _mockCategoryRepository
                .Setup(x => x.InsertNewCategory(It.IsAny<Category>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryService.InsertNewCategory(categoryRequest);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnCategoryResponse_WhenCategoryIsDeleted()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id = id,
                CategoryName = "Fuck Putin",
                Products = new List<Product>()
            };
            CategoryRequest categoryRequest = new()
            {
                CategoryName= "Fuck Putin"
            };

            _mockCategoryRepository
                .Setup(x => x.DeleteCategory(It.IsAny<int>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryService.DeleteCategory(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.NotNull(result.Products);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnNull_WhenCategoryIsNotDeleted()
        {
            //Arrange
            int id = 1;
            CategoryRequest categoryRequest = new()
            {
                CategoryName = "Fuck Putin"
            };

            _mockCategoryRepository
                .Setup(x => x.DeleteCategory(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryService.DeleteCategory(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnCategoryResponse_WhenCategoryIsUpdated()
        {
            //Arrange
            int id = 1;
            Category category = new()
            {
                Id=id,
                CategoryName = "Caris and Merthing should get married",
                Products=new List<Product>()
            };
            CategoryRequest categoryRequest = new()
            {
                CategoryName = "Caris and Merthing should get married"

            };

            _mockCategoryRepository
                .Setup(x => x.UpdateCategory(It.IsAny<int>(), It.IsAny<Category>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryService.UpdateCategory(id, categoryRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnNull_WhenCategoryIsNotUpdated()
        {
            //Arrange
            int id = 1;
            CategoryRequest categoryRequest = new()
            {
                CategoryName = "Caris and Merthing should get married"
            };

            _mockCategoryRepository
                .Setup(x => x.UpdateCategory(It.IsAny<int>(), It.IsAny<Category>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryService.UpdateCategory(id, categoryRequest);
            //Assert
            Assert.Null(result);
        }
    }
}
