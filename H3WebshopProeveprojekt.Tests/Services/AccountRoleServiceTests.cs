using H3WebshopProeveprojekt.Api.Database;
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
    public class AccountRoleServiceTests
    {
        private readonly AccountRoleService _accountRoleService;
        private readonly Mock<IAccountRoleRepository> _mockAccountRoleRepository = new();

        public AccountRoleServiceTests()
        {
            _accountRoleService = new(_mockAccountRoleRepository.Object);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnListOfAccountRoles_WhenAccountRolesExists()
        {
            //Arrange
            int id = 1;
            List<AccountRole> accountRoles = new()
            {
                new()
                {
                    Id = id,
                    Name = "Poor Caris, feeling the loss of Merthin having married, after he learned she took the vows."
                },
                new()
                {
                    Id=id+1,
                    Name= "Poor Merthin, having lived for years, hoping for Caris, only to learn she took the vows."
                }
            };
            _mockAccountRoleRepository
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(accountRoles);
            //Act
            var result = await _accountRoleService.GetAllAccountRoles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountRoleResponse>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnEmptyListOfAccountRoles_WhenAccountNoRolesExists()
        {
            //Arrange
            List<AccountRole> accountRoles = new();
            _mockAccountRoleRepository
                .Setup(x => x.GetAllAccountRoles())
                .ReturnsAsync(accountRoles);
            //Act
            var result = await _accountRoleService.GetAllAccountRoles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountRoleResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetAccountRolesById_ShouldReturnAccountRole_WhenAccountRoleExist()
        {
            //Arrange
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "Caris and Merthin must get back together somehow, but how? I must read!!"
            };
            _mockAccountRoleRepository
                .Setup(x => x.GetAccountRoleById(id))
                .ReturnsAsync(accountRole);
            //Act
            var result = await _accountRoleService.GetAccountRoleByID(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRoleResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetAccountRolesById_ShouldReturnNull_WhenTheAccountRoleDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockAccountRoleRepository
                .Setup(x => x.GetAccountRoleById(id))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleService.GetAccountRoleByID(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnAccountRole_WhenAccountRoleIsCreated()
        {
            //Arrange
            int id = 1;
            AccountRole newAccountRole = new()
            {
                Id = id,
                Name = "AAAARgh, I can't wait to find out how Caris and Merthin get together, and have a family!"
            };
            _mockAccountRoleRepository
                .Setup(x => x.GetAccountRoleById(It.IsAny<int>()))
                .ReturnsAsync(newAccountRole);
            //Act
            var result = await _accountRoleService.GetAccountRoleByID(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRoleResponse>(result);
            Assert.Equal(id,result.Id);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnNull_WhenAccountRoleIsNotCreated()
        {
            //Arrange
            int id = 1;
            _mockAccountRoleRepository
                .Setup(x => x.GetAccountRoleById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleService.GetAccountRoleByID(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnAccountRoleResponse_WhenAccountRoleIsUpdated()
        {
            //Arrange
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "I'm running out of chants for Caris and Merthin, I hope for their love."
            };
            AccountRoleRequest accountRoleRequest = new()
            {
                Name = "Godwyn is a blight on Kingsbridge priory."
            };
            _mockAccountRoleRepository
                .Setup(x => x.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRole>()))
                .ReturnsAsync(accountRole);
            //Act
            var result = await _accountRoleService.UpdateAccountRole(id, accountRoleRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRoleResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnNull_WhenNoAccountRoleIsUpdated()
        {
            //Arrange
            int id = 1;
            AccountRoleRequest accountRoleRequest = new()
            {
                Name = "Godwyn is a blight on Kingsbridge priory."
            };
            _mockAccountRoleRepository
                .Setup(x => x.UpdateAccountRole(It.IsAny<int>(), It.IsAny<AccountRole>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleService.UpdateAccountRole(id, accountRoleRequest);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteAccountRole_ShouldReturnNull_WhenNoAccountRoleIsDeleted()
        {
            //Arrange
            int id = 1;

            _mockAccountRoleRepository
                .Setup(x => x.DeleteAccountRole(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountRoleService.DeleteAccountRole(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteAccountRole_ShouldReturnAccountRole_WhenAccountRoleIsDeleted()
        {
            //Arrange
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "What will be the reason for Merthin to leave Florence for Kingsbrigde. Or will Caris find a way to slip out of England to Florence? But the series is about Kingsbrigde, so it must be Merthing going back. Will his wife and kid die?"
            };

            _mockAccountRoleRepository
                .Setup(x => x.DeleteAccountRole(It.IsAny<int>()))
                .ReturnsAsync(accountRole);
            //Act
            var result = await _accountRoleService.DeleteAccountRole(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRoleResponse>(result);
            Assert.Equal(id, result.Id);
        }
    }
}
