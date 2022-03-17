using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Services
{
    public interface IAccountService
    {
        public Task<List<AccountResponse>> GetAllAccounts();
        public Task<AccountResponse> GetAccountById(int id);
        public Task<AccountResponse> InsertNewAccount(AccountRequest accountRequest);
        public Task<AccountResponse> UpdateAccount(int id, AccountRequest accountRequest);
        public Task<AccountResponse> DeleteAccount(int id);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountResponse> DeleteAccount(int id)
        {
            Account account = await _accountRepository.DeleteAccount(id);
            if (account != null)
            {
                return MapAccountToAccountResponse(account);
            }
            return null;
        }

        public async Task<AccountResponse> GetAccountById(int id)
        {
            Account account = await _accountRepository.GetAccountById(id);
            if (account != null)
            {
                return MapAccountToAccountResponse(account);
            }
            return null;
        }

        public async Task<List<AccountResponse>> GetAllAccounts()
        {
            List<Account> accounts = await _accountRepository.GetAllAccounts();
            if (accounts != null)
            {
                return accounts.Select(account => MapAccountToAccountResponse(account)).ToList();
            }
            return null;
        }

        public async Task<AccountResponse> InsertNewAccount(AccountRequest accountRequest)
        {
            Account account = MapAccountRequestToAccount(accountRequest);
            Account insertedAccount = await _accountRepository.InsertNewAccount(account);
            if (insertedAccount != null)
            {
                return MapAccountToAccountResponse(insertedAccount);
            }
            return null;
        }

        public async Task<AccountResponse> UpdateAccount(int id, AccountRequest accountRequest)
        {
            Account account = MapAccountRequestToAccount(accountRequest);
            Account updatedAccount = await _accountRepository.UpdateAccount(id,account);
            if (updatedAccount != null)
            {
                return MapAccountToAccountResponse(updatedAccount);
            }
            return null;
        }

        private static Account MapAccountRequestToAccount(AccountRequest accountRequest)
        {
            return new Account()
            {
                Username = accountRequest.Username,
                Password = accountRequest.Password,
                UserFirstName = accountRequest.UserFirstName,
                UserLastName = accountRequest.UserLastName,
                AccountRoleId = accountRequest.AccountRoleId,
            };
        }

        private static AccountResponse MapAccountToAccountResponse(Account account)
        {
            return new AccountResponse()
            {
                Id = account.Id,
                Username = account.Username,
                Password = account.Password,
                UserFirstName = account.UserFirstName,
                UserLastName = account.UserLastName,
                AccountRoleId = account.AccountRoleId,
                AccountRole = new()
                {
                    Id = account.AccountRole.Id,
                    Name = account.AccountRole.Name,
                }
            };
        }
    }
}
