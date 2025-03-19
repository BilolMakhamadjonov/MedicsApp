using Medics.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Medics.DataAccess.Auth;

public class JwtTokenHandler : IJwtTokenHandler
{
    private readonly JwtOption jwtOption;

    public JwtTokenHandler(IOptions<JwtOption> options)
    {
        jwtOption = options.Value;
    }

    public JwtSecurityToken GenerateAccesToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(CustomClaimNames.Id, user.Id.ToString()),
            new Claim(CustomClaimNames.Role, user.Role.ToString()),
            new Claim(CustomClaimNames.Email, user.Email) // Email ham token ichida bo'lsin
        };

        return GenerateToken(claims);
    }

    public JwtSecurityToken GenerateAccessToken(UserForCreationDto user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        return GenerateToken(claims);
    }

    private JwtSecurityToken GenerateToken(List<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOption.SecretKey));

        return new JwtSecurityToken(
            issuer: jwtOption.Issuer,
            audience: jwtOption.Audience,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(jwtOption.ExpirationInMinutes)),
            claims: claims,
            signingCredentials: new SigningCredentials(
                authSigningKey,
                SecurityAlgorithms.HmacSha256)
        );
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];
        using var randomGenerator = RandomNumberGenerator.Create();
        randomGenerator.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}