using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Services
{
    public interface IAccountRoleService
    {
        public Task<List<AccountRoleResponse>> GetAllAccountRoles();
        public Task<AccountRoleResponse> GetAccountRoleByID(int id);
        public Task<AccountRoleResponse> InsertNewAccountRole(AccountRoleRequest accountRoleRequest);
        public Task<AccountRoleResponse> UpdateAccountRole(int id, AccountRoleRequest accountRoleRequest);
        public Task<AccountRoleResponse> DeleteAccountRole(int id);
    }
    public class AccountRoleService : IAccountRoleService
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        public AccountRoleService(IAccountRoleRepository accountRoleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
        }
        public async Task<AccountRoleResponse> DeleteAccountRole(int id)
        {
            AccountRole deletedAccount = await _accountRoleRepository.DeleteAccountRole(id);
            if (deletedAccount != null)
            {
                return MapAccountRoleToAccountRoleResponse(deletedAccount);
            }
            return null;
        }

        public async Task<AccountRoleResponse> GetAccountRoleByID(int id)
        {
            AccountRole accountRole = await _accountRoleRepository.GetAccountRoleById(id);
            if (accountRole != null)
            {
                return MapAccountRoleToAccountRoleResponse(accountRole);
            }
            return null;
        }

        public async Task<List<AccountRoleResponse>> GetAllAccountRoles()
        {
            List<AccountRole> accountRoles = await _accountRoleRepository.GetAllAccountRoles();
            if (accountRoles != null)
            {
                return accountRoles.Select(accountRole => MapAccountRoleToAccountRoleResponse(accountRole)).ToList();
            }
            return null;
        }

        public async Task<AccountRoleResponse> InsertNewAccountRole(AccountRoleRequest accountRoleRequest)
        {
            AccountRole accountRole = MapAccountRoleRequestToAccountRole(accountRoleRequest);
            AccountRole insertedAccountRole = await _accountRoleRepository.InsertNewAccountRole(accountRole);
            if (insertedAccountRole != null)
            {
                return MapAccountRoleToAccountRoleResponse(insertedAccountRole);
            }
            return null;
        }

        public async Task<AccountRoleResponse> UpdateAccountRole(int id, AccountRoleRequest accountRoleRequest)
        {
            AccountRole accountRole = MapAccountRoleRequestToAccountRole(accountRoleRequest);
            AccountRole updatedAccountRole = await _accountRoleRepository.UpdateAccountRole(id, accountRole);
            if (updatedAccountRole != null)
            {
                return MapAccountRoleToAccountRoleResponse(updatedAccountRole);
            }
            return null;
        }

        private static AccountRoleResponse MapAccountRoleToAccountRoleResponse(AccountRole accountRole)
        {
            return new AccountRoleResponse()
            {
                Id = accountRole.Id,
                Name = accountRole.Name,
            };
        }
        private static AccountRole MapAccountRoleRequestToAccountRole(AccountRoleRequest accountRoleRequest)
        {
            return new AccountRole()
            {
                Name = accountRoleRequest.Name
            };
        }
    }
}
