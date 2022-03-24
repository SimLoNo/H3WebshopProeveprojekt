using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccounts();
        public Task<Account> GetAccountById(int id);
        public Task<Account> InsertNewAccount(Account account);
        public Task<Account> UpdateAccount(int id, Account account);
        public Task<Account> DeleteAccount(int id);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly H3WebshopProeveprojektContext _context;
        public AccountRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }

        public async Task<Account> DeleteAccount(int id)
        {
            Account account = await _context.Account
                .Include(x => x.AccountRole)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (account != null)
            {
                _context.Account.Remove(account);
                await _context.SaveChangesAsync();
            }
            return account;
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Account
                .Include(x => x.AccountRole)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Account
                .Include(x => x.AccountRole).ToListAsync();
        }

        public async Task<Account> InsertNewAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            account.AccountRole = await _context.AccountRole.FirstOrDefaultAsync(x => x.Id == account.AccountRoleId);
            return account;
        }

        public async Task<Account> UpdateAccount(int id, Account account)
        {
            Account updatedAccount = await _context.Account
                .FirstOrDefaultAsync(x => x.Id == id);

            if (updatedAccount != null)
            {
                updatedAccount.Username = account.Username;
                updatedAccount.Password = account.Password;
                updatedAccount.UserFirstName = account.UserFirstName;
                updatedAccount.UserLastName = account.UserLastName;
                updatedAccount.AccountRoleId = account.AccountRoleId;
                await _context.SaveChangesAsync();
                updatedAccount.AccountRole = await _context.AccountRole.FirstOrDefaultAsync(x => x.Id == account.AccountRoleId);
            }
            return updatedAccount;
        }
    }
}
