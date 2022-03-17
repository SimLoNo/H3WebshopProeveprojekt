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
    public class AccountRepositoryTests
    {
        private readonly DbContextOptions<H3WebshopProeveprojektContext> _options;
        private readonly H3WebshopProeveprojektContext _context;
        private readonly AccountRepository _repository;

        public AccountRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<H3WebshopProeveprojektContext>()
                .UseInMemoryDatabase(databaseName: "H3WebshopProeveprojektAccount")
                .Options;

            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnListOfAccounts_WhenAccountsExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "Lovebirds"
            });
            _context.Account.Add(new()
            {
                Id=id,
                Username = "ILoveCaris",
                Password = "CarisIsMyLife",
                UserFirstName = "Merthin",
                UserLastName = "Fitzgerald",
                AccountRoleId = id
            });
            _context.Account.Add(new()
            {
                Id = id+1,
                Username = "ImTornBetweenMyWishes",
                Password = "MerthinOrNunnery?",
                UserFirstName = "Caris",
                UserLastName = "Wooler",
                AccountRoleId = id
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAllAccounts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Account>>(result);
            Assert.Equal(2,result.Count);
        }

        [Fact]
        public async void GetAllAccounts_ShouldReturnEmptyListOfAccounts_WhenNoAccountsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAllAccounts();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Account>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnAccount_WhenTheAccountExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.Account.Add(new()
            {
                Id = id,
                Username = "ILoveCaris",
                Password = "CarisIsMyLife",
                UserFirstName = "Merthin",
                UserLastName = "Fitzgerald",
                AccountRoleId = id
            });
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "Lovebirds"
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAccountById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Account>(result);
            Assert.Equal(id,result.Id);
        }

        [Fact]
        public async void GetAccountById_ShouldReturnNull_WhenTheAccountDoesNotExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAccountById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateAccount_ShouldReturnAccountWithAccountRole_WhenAccountExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            AccountRole newAccountRole = new()
            {
                Id = id + 1,
                Name = "Don't be a bitch Caris."
            };
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "I hope Caris gets declared innocent of witchcraft, renounces her vows, and marry Merthin."
            });
            _context.AccountRole.Add(newAccountRole);
            _context.Account.Add(new()
            {
                Id = id,
                Username = "ILoveCaris",
                Password = "CarisIsMyLife",
                UserFirstName = "Merthin",
                UserLastName = "Fitzgerald",
                AccountRoleId = id
            });
            Account account = new()
            {
                Id = id,
                Username = "MarryMerthin",
                Password = "ComeonCaris",
                UserFirstName = "YouHaveTheBestManInEnglandInYourHands",
                UserLastName = "YouKeepHimInPainByYourIndecisiveness",
                AccountRoleId = id + 1

            };
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.UpdateAccount(id,account);
            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.AccountRole);
            Assert.IsType<Account>(result);
            Assert.Equal(account.Username, result.Username);
            Assert.Equal(newAccountRole, result.AccountRole);
        }


        [Fact]
        public async void UpdateAccount_ShouldReturnNull_WhenTheAccountDoesNotExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            Account account = new()
            {
                Id = id,
                Username = "MarryMerthin",
                Password = "ComeonCaris",
                UserFirstName = "YouHaveTheBestManInEnglandInYourHands",
                UserLastName = "YouKeepHimInPainByYourIndecisiveness",
                AccountRoleId = id + 1

            };
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.UpdateAccount(id,account);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewAccount_ShouldReturnAccount()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            Account account = new()
            {
                Username = "CarisFoundThomas'EntryGift",
                Password = "IsHeInTrouble?",
                UserFirstName = "WillWeFindOutTheSecret",
                UserLastName = "WillActionsBeTakenOnTheSecretIfTheyFindOut?",
                AccountRoleId = id
            };
            //Act
            var result = await _repository.InsertNewAccount(account);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Account>(result);
        }

        [Fact]
        public async void DeleteAccount_ShouldReturnAccount_WhenTheAccountIsDeleted()
        {
            //Arrange
            int id = 1;
            Account account = new()
            {
                Id = id,
                Username = "Don't be stupid Caris.",
                Password = "Merthin is your future",
                UserFirstName = "Caris",
                UserLastName = "Wooler",
                AccountRoleId = id
            };

            await _context.Database.EnsureDeletedAsync();
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "I hope Caris gets declared innocent of witchcraft, renounces her vows, and marry Merthin."
            });
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteAccount(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Account>(result);
            Assert.Equal(id, result.Id);
        }


        [Fact]
        public async void DeleteAccount_ShouldReturnNull_WhenTheAccountIsNotDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteAccount(id);
            //Assert
            Assert.Null(result);
        }
    }
}
