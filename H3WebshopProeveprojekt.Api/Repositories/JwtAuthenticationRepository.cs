using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface IJwtAuthenticationRepository
    {
        Task<Account> Authenticate(Account account);
    }
    public class JwtAuthenticationRepository : IJwtAuthenticationRepository
    {
        private readonly H3WebshopProeveprojektContext _context;
        public JwtAuthenticationRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }
        public async Task<Account> Authenticate(Account account)
        {
            Account foundAccount = await _context.Account.FirstOrDefaultAsync(x => x.Username == account.Username && x.Password == account.Password);
            if (foundAccount == null)
            {
                return null;
            }
            return foundAccount;


        }
    }
}
