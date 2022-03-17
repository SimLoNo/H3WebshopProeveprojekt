using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface IAccountRoleRepository
    {
        public Task<List<AccountRole>> GetAllAccountRoles();
        public Task<AccountRole> GetAccountRoleById(int id);
        public Task<AccountRole> InsertNewAccountRole(AccountRole accountRole);
        public Task<AccountRole> UpdateAccountRole(int id, AccountRole accountRole);
        public Task<AccountRole> DeleteAccountRole(int id);
    }
    public class AccountRoleRepository : IAccountRoleRepository
    {
        private readonly H3WebshopProeveprojektContext _context;
        public AccountRoleRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }
        public async Task<AccountRole> DeleteAccountRole(int id)
        {
            AccountRole accountRole = await _context.AccountRole.FirstOrDefaultAsync(x => x.Id == id);
            if (accountRole != null)
            {
                _context.AccountRole.Remove(accountRole);
                await _context.SaveChangesAsync();
            }
            return accountRole;
        }

        public async Task<AccountRole> GetAccountRoleById(int id)
        {
            return await _context.AccountRole.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AccountRole>> GetAllAccountRoles()
        {
            return await _context.AccountRole.ToListAsync();
        }

        public async Task<AccountRole> InsertNewAccountRole(AccountRole accountRole)
        {
            _context.AccountRole.Add(accountRole);
            await _context.SaveChangesAsync();
            return accountRole;
        }

        public async Task<AccountRole> UpdateAccountRole(int id, AccountRole accountRole)
        {
            AccountRole updatedAccountRole = await _context.AccountRole.FirstOrDefaultAsync(x => x.Id == id);
            if (updatedAccountRole != null)
            {
                updatedAccountRole.Name = accountRole.Name;
                await _context.SaveChangesAsync();
            }
            return updatedAccountRole;
        }
    }
}
