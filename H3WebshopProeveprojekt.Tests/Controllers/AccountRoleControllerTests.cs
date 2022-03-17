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
    public class AccountRoleControllerTests
    {
        private readonly AccountRoleController _accountRoleController;
        private readonly Mock<IAccountRoleService> _mockAccountRoleSerice = new();
        public AccountRoleControllerTests()
        {
            _accountRoleController = new(_mockAccountRoleSerice.Object);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnStatusCode200_WhenAccountRolesExists()
        {
            //Arrange
            int id = 1;
            List<AccountRoleResponse> accountRoles = new()
            {
                new()
                {
                    Id = id,
                    Name = "Almost off work, then I can continue reading World Without End!"
                },
                new()
                {
                    Id = id + 1,
                    Name = "Will Caris and Merthin meet while she is abroad, and get together again? But he is said to be in Florence, and she is only in northern france!"
                }
            };
            _mockAccountRoleSerice
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(accountRoles);
            //Act
            var result = await _accountRoleController.GetAllAccountRoles();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnStatusCode204_WhenNoAccountRolesExists()
        {
            //Arrange
            List<AccountRoleResponse> accountRoles = new();
            _mockAccountRoleSerice
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(accountRoles);
            //Act
            var result = await _accountRoleController.GetAllAccountRoles();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(() => throw new Exception("Even with Caris and Merthin, exceptions is still Putins illegal invasion of Ukraine."));
            //Act
            var result = await _accountRoleController.GetAllAccountRoles();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnStatusCode500_WhenNullIsReturned()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleController.GetAllAccountRoles();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountRolesById_ShouldReturnStatusCode200_WhenAccountRoleIsFound()
        {
            //Arrange
            int id = 1;
            AccountRoleResponse accountRoleResponse = new()
            {
                Id = id,
                Name = "There is still roughly 1/3 of the book left, so i wouldn't think the happy ending for Caris and Merthin is near. :("
            };
            _mockAccountRoleSerice
                .Setup(x => x.GetAccountRoleByID(id))
                .ReturnsAsync(accountRoleResponse);
            //Act
            var result = await _accountRoleController.GetAccountRoleById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountRolesById_ShouldReturnStatusCode404_WhenAccountRoleIsNotFound()
        {
            //Arrange
            int id = 1;
            _mockAccountRoleSerice
                .Setup(x => x.GetAccountRoleByID(id))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleController.GetAccountRoleById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountRolesById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            int id = 1;
            _mockAccountRoleSerice
                .Setup(x => x.GetAccountRoleByID(id))
                .ReturnsAsync(() => throw new Exception("Fuck Putin and his invasion, SLAVE UKRAINI!"));
            //Act
            var result = await _accountRoleController.GetAccountRoleById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnStatusCode200_WhenAccountRoleIsCreated()
        {
            //Arrange
            int id = 1;
            AccountRoleResponse accountRoleResponse = new()
            {
                Id = id,
                Name = "Will Merthin and Caris get lots of kids, or will it be like Jack and Aliena, and be too late when they get married?"
            };
            _mockAccountRoleSerice
                .Setup(x => x.InsertNewAccountRole(It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(accountRoleResponse);
            //Act
            var result = await _accountRoleController.InsertNewAccountRole(It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnStatusCode404_WhenAccountRoleIsNotCreated()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.InsertNewAccountRole(It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleController.InsertNewAccountRole(It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.InsertNewAccountRole(It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(() => throw new Exception("Fuck Putin and his cronies!"));
            //Act
            var result = await _accountRoleController.InsertNewAccountRole(It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccountRole_ShouldReturnStatusCode200_WhenAccountRoleIsDeleted()
        {
            //Arrange
            int id = 1;
            AccountRoleResponse accountRoleResponse = new()
            {
                Id = id,
                Name = "Will Merthin and Caris get lots of kids, or will it be like Jack and Aliena, and be too late when they get married?"
            };
            _mockAccountRoleSerice
                .Setup(x => x.DeleteAccountRole(It.IsAny<int>()))
                .ReturnsAsync(accountRoleResponse);
            //Act
            var result = await _accountRoleController.DeleteAccountRole(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccountRole_ShouldReturnStatusCode404_WhenAccountRoleIsNotDeleted()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.DeleteAccountRole(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleController.DeleteAccountRole(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccountRole_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.DeleteAccountRole(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("Putin is not going to get away with invading Ukraine."));
            //Act
            var result = await _accountRoleController.DeleteAccountRole(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnStatusCode200_WhenAccountRoleIsUpdated()
        {
            //Arrange
            int id =1;
            AccountRoleResponse accountRoleResponse = new()
            {
                Id = id,
                Name = "Has Merthins wife and child died in Florence, and he is returning to Kingsbridge in sorrow, since the italian merchant left Florence?"
            };
            _mockAccountRoleSerice
                .Setup(x => x.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(accountRoleResponse);
            //Act
            var result = await _accountRoleController.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnStatusCode404_WhenAccountRoleIsNotUpdated()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleController.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _mockAccountRoleSerice
                .Setup(x => x.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>()))
                .ReturnsAsync(() => throw new Exception("Slave Ukraini!"));
            //Act
            var result = await _accountRoleController.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRoleRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
