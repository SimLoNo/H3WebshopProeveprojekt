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
    public class AccountRoleRepositoryTests
    {
        private readonly DbContextOptions<H3WebshopProeveprojektContext> _options;
        private readonly H3WebshopProeveprojektContext _context;
        private readonly AccountRoleRepository _repository;

        public AccountRoleRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<H3WebshopProeveprojektContext>()
                .UseInMemoryDatabase(databaseName: "H3WebshopProeveprojektAccountRole")
                .Options;

            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnListOfAccountRoles_WhenAccountRolesExists()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "Fuck Prior Godwyn"
            });
            _context.AccountRole.Add(new()
            {
                Id = id+1,
                Name = "Poor Caris, being forced to give up Merthin and become a nun."
            });
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAllAccountRoles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountRole>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllAccountRoles_ShouldReturnEmptyListOfAccountRoles_WhenNoAccountRolesExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAllAccountRoles();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<AccountRole>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetAccountRoleById_ShouldReturnAccountRole_WhenAccountRoleExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "I grief for Caris and Merthin. :("
            };
            _context.AccountRole.Add(accountRole);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAccountRoleById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRole>(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async void GetAccountRoleById_ShouldReturnNull_WhenAccountRoleDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            int id = 1;
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.GetAccountRoleById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void InsertNewAccountRole_ShouldReturnAccountRole()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "Fuck, Ralph must've come back as lord of Wigleigh, poor Wulfric and Gwenda!"
            };
            //Act
            var result = await _repository.InsertNewAccountRole(accountRole);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRole>(result);

        }

        [Fact]
        public async void UpdateAccountRole_ShouldReturnAccountRole_WhenAccountRoleIsUpdated()
        {
            //Arrange
            int id = 1;
            string newName = "Please let it be so, lord Ken Follet!";
            await _context.Database.EnsureDeletedAsync();
            _context.AccountRole.Add(new()
            {
                Id = id,
                Name = "Please let Caris and Merthin get married and live hapilly!"
            });
            await _context.SaveChangesAsync();
            AccountRole accountRole = new()
            {
                Id = id,
                Name = newName
            };
            //Act
            var result = await _repository.UpdateAccountRole(id, accountRole);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRole>(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(newName, result.Name);
        }

        [Fact]
        public async void UpdateAccountRole_shouldReturnNull_WhenNoAccountRoleIsUpdated()
        {

            //Arrange
            int id = 1;
            string newName = "Please let Merthin and Caris be together and happy!";
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            AccountRole accountRole = new()
            {
                Id = id,
                Name = newName
            };
            //Act
            var result = await _repository.UpdateAccountRole(id, accountRole);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteAccountRole_shouldReturnNull_WhenNoAccountRoleIsDeleted()
        {
            //arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteAccountRole(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteAccountRole_shouldReturnAccountRole_WhenTheAccountRoleIsDeleted()
        {
            //arrange
            int id = 1;
            AccountRole accountRole = new()
            {
                Id = id,
                Name = "PLEASE get Merthin home from Florence, with a way to be with Caris!!!!"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.AccountRole.Add(accountRole);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteAccountRole(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<AccountRole>(result);
            Assert.Equal(id, result.Id);
        }
    }
}
