using Medics.Core.Entities;
using Medics.DataAccess.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Medics.DataAccess.Auth;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(UserForCreationDto userDto);
    JwtSecurityToken GenerateAccesToken(User user);
    string GenerateRefreshToken();
}