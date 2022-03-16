using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using System.Collections.Generic;
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
        public Task<AccountRoleResponse> DeleteAccountRole(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountRoleResponse> GetAccountRoleByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<AccountRoleResponse>> GetAllAccountRoles()
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountRoleResponse> InsertNewAccountRole(AccountRoleRequest accountRoleRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountRoleResponse> UpdateAccountRole(int id, AccountRoleRequest accountRoleRequest)
        {
            throw new System.NotImplementedException();
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
