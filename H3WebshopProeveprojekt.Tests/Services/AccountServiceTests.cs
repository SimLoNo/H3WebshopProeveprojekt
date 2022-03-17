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
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly Mock<IAccountRepository> _mockAccountRepository = new();
        public AccountServiceTests()
        {
            _accountService = new(_mockAccountRepository.Object);
        }

        [Fact]
        public async void DeleteAccount_ShouldReturnAccountResponse_WhenTheAccountIsDeleted()
        {
            //Arrange
            int id = 1;
            Account account = new()
            {
                Id = id,
                Username = "Will they get together too late to have children?",
                Password = "Please don't let that happen lord Follet!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Lovesick"
                }
            };

            _mockAccountRepository
                .Setup(x => x.DeleteAccount(It.IsAny<int>()))
                .ReturnsAsync(account);
            //Act
            var result = await _accountService.DeleteAccount(id);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AccountRole);
            Assert.IsType<AccountResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void DeleteAccount_ShouldReturnNull_WhenTheAccountIsNotDeleted()
        {
            //Arrange
            int id = 1;
            _mockAccountRepository
                .Setup(x => x.DeleteAccount(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountService.DeleteAccount(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnAccountResponse_WhenTheAccountExists()
        {
            //Arrange
            int id = 1;
            Account account = new()
            {
                Id = id,
                Username = "Will they get together too late to have children?",
                Password = "Please don't let that happen lord Follet!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Lovesick"
                }
            };

            _mockAccountRepository
                .Setup(x => x.GetAccountById(It.IsAny<int>()))
                .ReturnsAsync(account);
            //Act
            var result = await _accountService.GetAccountById(id);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AccountRole);
            Assert.IsType<AccountResponse>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnNull_WhenTheAccountDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockAccountRepository
                .Setup(x => x.GetAccountById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _accountService.GetAccountById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnListOfAccounts_WhenAccountsExists()
        {
            //Arrange
            int id = 1;
            List<Account> accounts = new()
            {
                new()
                {
                    Id = id,
                    Username = "Will they get together too late to have children?",
                    Password = "Please don't let that happen lord Follet!",
                    UserFirstName = "Simon",
                    UserLastName = "Noerregaard",
                    AccountRoleId = id,
                    AccountRole = new()
                    {
                        Id = id,
                        Name = "Lovesick"
                    }
                },
                new()
                {
                    Id = id+1,
                    Username = "Why do Ken Follet have to torture me so!",
                    Password = "I just want Merthin and Caris to get married and raise a family together!",
                    UserFirstName = "Simon",
                    UserLastName = "Noerregaard",
                    AccountRoleId = id,
                    AccountRole = new()
                    {
                        Id = id,
                        Name = "Lovesick"
                    }
                }
            };

            _mockAccountRepository
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accounts);
            //Act
            var result = await _accountService.GetAllAccounts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountResponse>>(result);
            foreach (AccountResponse item in result)
            {
                Assert.Equal(id, item.AccountRole.Id);
            }


        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnEmptyListOfAccounts_WhenAccountsExists()
        {
            //Arrange
            List<Account> accounts = new();

            _mockAccountRepository
                .Setup(x => x.GetAllAccounts())
                .ReturnsAsync(accounts);
            //Act
            var result = await _accountService.GetAllAccounts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountResponse>>(result);
            Assert.Empty(accounts);
        }

        [Fact]
        public async void InsertNewAccount_shouldReturnAccountResponse()
        {
            //Arrange
            int id = 1;
            Account account = new()
            {
                Id = id,
                Username = "Why do Ken Follet have to torture me so!",
                Password = "I just want Merthin and Caris to get married and raise a family together!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Lovesick"
                }
            };
            AccountRequest accountRequest = new()
            {

                Username = "Why do Ken Follet have to torture me so!",
                Password = "I just want Merthin and Caris to get married and raise a family together!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
            };

            _mockAccountRepository
                .Setup(x => x.InsertNewAccount(It.IsAny<Account>()))
                .ReturnsAsync(account);
            //Act
            var result = await _accountService.InsertNewAccount(accountRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountResponse>(result);
            Assert.Equal(id, result.Id);
            Assert.NotNull(result.AccountRole);
        }

        [Fact]
        public async void UpdateAccount_ShouldReturnAccountResponse_WhenTheAccountIsUpdated()
        {//Arrange
            int id = 1;
            Account account = new()
            {
                Id = id,
                Username = "Why do Ken Follet have to torture me so!",
                Password = "I just want Merthin and Caris to get married and raise a family together!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
                AccountRole = new()
                {
                    Id = id,
                    Name = "Lovesick"
                }
            };
            AccountRequest accountRequest = new()
            {

                Username = "Why do Ken Follet have to torture me so!",
                Password = "I just want Merthin and Caris to get married and raise a family together!",
                UserFirstName = "Simon",
                UserLastName = "Noerregaard",
                AccountRoleId = id,
            };

            _mockAccountRepository
                .Setup(x => x.UpdateAccount(It.IsAny<int>(),It.IsAny<Account>()))
                .ReturnsAsync(account);
            //Act
            var result = await _accountService.UpdateAccount(id,accountRequest);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountResponse>(result);
            Assert.Equal(id, result.Id);


        }
    }
}
