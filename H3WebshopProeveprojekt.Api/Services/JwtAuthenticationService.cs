using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Services
{
    public interface IJwtAuthenticationService
    {
        Task<string> Authenticate(AccountRequest accountRequest);
    }
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IJwtAuthenticationRepository _jwtAuthenticationRepository;
        private readonly string _key;

        public JwtAuthenticationService(IJwtAuthenticationRepository jwtAuthenticationRepository)
        {
            _jwtAuthenticationRepository = jwtAuthenticationRepository;
            _key = "Brianna for house wife!";
        }

        public async Task<string> Authenticate(AccountRequest accountRequest)
        {
            Account requestedAccount = MapAccountRequestToAccount(accountRequest);
            Account foundAccount = await _jwtAuthenticationRepository.Authenticate(requestedAccount);
            if (foundAccount == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundAccount.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static Account MapAccountRequestToAccount(AccountRequest accountRequest)
        {
            return new Account
            {
                Username = accountRequest.Username,
                Password = accountRequest.Password,
                AccountRoleId = accountRequest.AccountRoleId
            };
        }
    }
}
