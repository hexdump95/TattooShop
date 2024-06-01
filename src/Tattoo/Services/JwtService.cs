using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using Tattoo.Entities;
using Tattoo.Services.Interfaces;

namespace Tattoo.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = [];
            claims.Add(new Claim("sub", user.Username));

            IList<string> roles = user.UserRoles
                .Select(userRole => userRole.Role.ToString())
                .ToList();

            claims.Add(new Claim("roles", JsonConvert.SerializeObject(roles), JsonClaimValueTypes.JsonArray));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Int32.Parse(_configuration["Jwt:ExpiresAfterMinutes"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
