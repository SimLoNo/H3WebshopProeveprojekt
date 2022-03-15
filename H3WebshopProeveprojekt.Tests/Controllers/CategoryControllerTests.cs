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
    public class CategoryControllerTests
    {
        private readonly CategoryController _categoryController;
        private readonly Mock<ICategoryService> _mockCategoryService = new();

        public CategoryControllerTests()
        {
            _categoryController = new(_mockCategoryService.Object);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnStatusCode200_WhenCategoriesExists()
        {
            //Arrange
            int id = 1;
            List<CategoryResponse> categories = new()
            {
                new()
                {
                    Id = id,
                    CategoryName = "Ralph Fitzgerald is evil, but fingers crossed for Gwenda!",
                    Products = new()
                },
                new()
                {
                    Id = id+1,
                    CategoryName = "Caris, don't get pregnant, and be forced to marry Merthin before you are ready. Get ready and marry him anyway, though.",
                    Products = new()
                }
            };
            _mockCategoryService
                .Setup(c => c.GetAllCategories())
                .ReturnsAsync(categories);
            //Act
            var result = await _categoryController.GetAllCategories();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnStatusCode204_WhenNoCategoriesExist()
        {
            //Arrange
            List<CategoryResponse> categories = new();

            _mockCategoryService
                .Setup(c => c.GetAllCategories())
                .ReturnsAsync(categories);
            //Act
            var result = await _categoryController.GetAllCategories();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnStatusCode500_WhenNullIsReturned()
        {
            //Arrange
            _mockCategoryService
                .Setup(c => c.GetAllCategories())
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryController.GetAllCategories();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockCategoryService
                .Setup(c => c.GetAllCategories())
                .ReturnsAsync(() => throw new Exception("This is another exception caused by the invasion of Ukraine. Vladimir Putin ???? - 2022"));
            //Act
            var result = await _categoryController.GetAllCategories();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnStatusCode200_WhenCategoryExists()
        {
            //Arrange
            int id = 1;
            CategoryResponse category = new()
            {
                Id = id,
                CategoryName = "Jack and Aliena should have left Kingsbridge to get married, and gotten more children!",
                Products = new()
            };
            _mockCategoryService
                .Setup(x => x.GetCategoryById(id))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryController.GetCategoryById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnStatusCode404_WhenCategoryDoesNotExists()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.GetCategoryById(id))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryController.GetCategoryById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.GetCategoryById(id))
                .ReturnsAsync(() => throw new Exception("Caris and Merthin need to be married, and survive hapilly through the Black Death!"));
            //Act
            var result = await _categoryController.GetCategoryById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnStatusCode200_WhenCategoryIsCreated()
        {
            //Arrange
            int id = 1;
            CategoryResponse category = new()
            {
                Id = id,
                CategoryName = "Fuck William Hamleigh!",
                Products = new()
            };
            _mockCategoryService
                .Setup(x => x.InsertNewCategory(It.IsAny<CategoryRequest>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryController.InsertNewCategory(It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnStatusCode404_WhenCategoryIsNotCreated()
        {
            //Arrange
            _mockCategoryService
                .Setup(x => x.InsertNewCategory(It.IsAny<CategoryRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryController.InsertNewCategory(It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewCategory_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockCategoryService
                .Setup(x => x.InsertNewCategory(It.IsAny<CategoryRequest>()))
                .ReturnsAsync(() => throw new Exception("Prior Phillip should have let Aliena and Jack live as a married couple, insted of requiring them to sleep seperate!"));
            //Act
            var result = await _categoryController.InsertNewCategory(It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        // I am uncertain about the returns on the update endpoint. To me it looks like the repository, always returns the sent Category,
        // Regardless whether it's updated or not.
        [Fact]
        public async void UpdateCategory_ShouldReturnStatusCode200_WhenCategoryIsUpdated()
        {
            //Arrange
            int id = 1;
            CategoryResponse category = new()
            {
                Id = id,
                CategoryName = "Fuck Ralph Fitzgerald too, for not keeing his deal!",
                Products = new()
            };

            _mockCategoryService
                .Setup(x => x.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryRequest>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryController.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnStatusCode404_whenTheCategoryIsNotUpdated()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryController.UpdateCategory(id, It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
            
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnStatusCode500_whenExceptionIsRaised()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.UpdateCategory(It.IsAny<int>(), It.IsAny<CategoryRequest>()))
                .ReturnsAsync(() => throw new Exception("Slava Ukraini."));
            //Act
            var result = await _categoryController.UpdateCategory(id, It.IsAny<CategoryRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnStatusCode200_WhenCategoryIsDeleted()
        {
            //Arrange
            int id = 1;
            CategoryResponse category = new()
            {
                Id = id,
                CategoryName = "Tom and Ellen loved each other.",
                Products = new()
            };
            _mockCategoryService
                .Setup(x => x.DeleteCategory(It.IsAny<int>()))
                .ReturnsAsync(category);
            //Act
            var result = await _categoryController.DeleteCategory(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnStatusCode404_WhenCategoryIsNotDeleted()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.DeleteCategory(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _categoryController.DeleteCategory(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int id = 1;
            _mockCategoryService
                .Setup(x => x.DeleteCategory(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("Putin is going to die."));
            //Act
            var result = await _categoryController.DeleteCategory(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }


    }
}
