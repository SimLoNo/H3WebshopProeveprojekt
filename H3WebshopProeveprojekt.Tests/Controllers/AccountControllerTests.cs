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
    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IAccountService> _MockAccountService = new();
        public AccountControllerTests()
        {
            _accountController = new(_MockAccountService.Object);
        }

        [Fact]
        public async void InsertNewAccount_ShouldReturnStatusCode200_WhenAccountIsCreated()
        {
            //Arrange
            int id = 1;
            AccountResponse accountResponse = new()
            {
                Id = id,
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Fuck Ralph!"
                }
            };
            AccountRequest accountRequest = new()
            {
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
            };

            _MockAccountService
                .Setup(x => x.InsertNewAccount(It.IsAny<AccountRequest>()))
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.InsertNewAccount(accountRequest);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewAccount_ShouldReturnStatusCode404_WhenAccountIsNotCreated()
        {
            //Arrange
            int id =1;
            AccountRequest accountRequest = new()
            {
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
            };

            _MockAccountService
                .Setup(x => x.InsertNewAccount(It.IsAny<AccountRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountController.InsertNewAccount(It.IsAny<AccountRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void InsertNewAccount_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.InsertNewAccount(It.IsAny<AccountRequest>()))
                .ReturnsAsync(() => throw new Exception("Fuck Putins invasion of Ukraine!"));
            //Act
            var result = await _accountController.InsertNewAccount(It.IsAny<AccountRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnStatusCode200_WhenAccountsExists()
        {
            //Arrange
            int id = 1;
            List<AccountResponse> accountResponse = new()
            {
                new()
                {
                    Id = id,
                    Username = "Fuck Ralph!",
                    Password = "You can do it Wulfric and Gwenda!",
                    UserFirstName = "Will Ralph figure out he is the father?",
                    UserLastName = "He can't get away with Gwenda' son!",
                    AccountRoleId = id,
                    AccountRole = new()
                    {
                        Id = id,
                        Name = "Fuck Ralph!"
                    }
                }
            };
            _MockAccountService
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.GetAllAccounts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnStatusCode204_WhenNoAccountsExists()
        {
            //Arrange
            List<AccountResponse> accountResponse = new();
            _MockAccountService
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.GetAllAccounts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnStatusCode500_WhenNullIsReturned()
        {
            //Arrange
            List<AccountResponse> accountResponse = new();
            _MockAccountService
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountController.GetAllAccounts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            List<AccountResponse> accountResponse = new();
            _MockAccountService
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(() => throw new Exception("Fuck Putin and his cronies!"));
            //Act
            var result = await _accountController.GetAllAccounts();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnStatusCode200_WhenAccountExists()
        {
            //Arrange
            int id = 1;
            AccountResponse accountResponse = new()
            {
                Id = id,
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Fuck Ralph!"
                }
            };
            _MockAccountService
                .Setup(x => x.GetAccountById(It.IsAny<int>()))
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.GetAccountById(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnStatusCode404_WhenNoAccountExists()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.GetAccountById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountController.GetAccountById(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.GetAccountById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("Putin need to pull back his troops!"));
            //Act
            var result = await _accountController.GetAccountById(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccount_shouldReturnStatusCode200_whenAccountIsUpdated()
        {
            int id = 1;
            AccountResponse accountResponse = new()
            {
                Id = id,
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Fuck Ralph!"
                }
            };
            //Arrange
            _MockAccountService
                .Setup(x => x.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>()))
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccount_shouldReturnStatusCode404_whenTheAccountIsNotUpdated()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountController.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateAccount_shouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>()))
                .ReturnsAsync(() => throw new Exception("Fuck Putin and his invasion!"));
            //Act
            var result = await _accountController.UpdateAccount(It.IsAny<int>(), It.IsAny<AccountRequest>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccount_shouldReturnStatusCode200_whenTheAccountIsDeleted()
        {
            int id =1;
            AccountResponse accountResponse = new()
            {
                Id = id,
                Username = "Fuck Ralph!",
                Password = "You can do it Wulfric and Gwenda!",
                UserFirstName = "Will Ralph figure out he is the father?",
                UserLastName = "He can't get away with Gwenda' son!",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Fuck Ralph!"
                }
            };
            //Arrange
            _MockAccountService
                .Setup(x => x.DeleteAccount(It.IsAny<int>()))
                .ReturnsAsync(accountResponse);
            //Act
            var result = await _accountController.DeleteAccount(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccount_shouldReturnStatusCode404_whenTheAccountIsNotDeleted()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.DeleteAccount(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountController.DeleteAccount(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteAccount_shouldReturnStatusCode500_WhenExceptionIsRaised()
        {
            //Arrange
            _MockAccountService
                .Setup(x => x.DeleteAccount(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("Shame on Putin!"));
            //Act
            var result = await _accountController.DeleteAccount(It.IsAny<int>());
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
