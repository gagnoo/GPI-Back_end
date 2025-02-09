using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GPI.Infrastructure.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GPI.Infrastructure.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string GenerateToken(string username)
    {
        IConfigurationSection jwtSettings = configuration.GetSection("JwtSettings");
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256Signature);

        Claim[] claims =
        [
            new("username", username),
            new("sub", Guid.NewGuid().ToString())
        ];

        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtSettings["Issuer"]!,
            audience: jwtSettings["Audience"]!,
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["Expires"]!)));

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}