using Hubtel.Vault.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hubtel.Vault.Api.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(string email, string password);
        Task<string> GenerateToken(WalletUser user);
        Task<WalletUser?> AuthenticateUser(string email, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<WalletUser> _userManager;
        private readonly IConfiguration _configuration;
        private WalletUser _user;

        public AuthenticationService(UserManager<WalletUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            _user = await _userManager.FindByEmailAsync(email);
            return _user != null;
                //&& await _userManager.CheckPasswordAsync(_user, password);
        }

        public async Task<string> GenerateToken(WalletUser user)
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings").GetSection("SecretKey").Value);
            var secret = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var claims = await ListClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings.GetSection("validIssuer").Value,
            audience: jwtSettings.GetSection("validAudience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        private async Task<List<Claim>> ListClaims(WalletUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims;
        }

        public async Task<WalletUser?> AuthenticateUser(string email, string password)
        {
            var user =  await _userManager.FindByEmailAsync(email);
            var checkPassword = await _userManager.CheckPasswordAsync(_user, password);
            if (user != null && !checkPassword )
            {
                return user;
            }
            return null;
            
        }
    }
}
