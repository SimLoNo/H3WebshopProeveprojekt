using H3WebshopProeveprojekt.Api.Database.Entities;

namespace H3WebshopProeveprojekt.Api.JwtToken
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(Account account);
    }
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        public string Authenticate(Account account)
        {
            throw new System.NotImplementedException();
        }
    }
}
