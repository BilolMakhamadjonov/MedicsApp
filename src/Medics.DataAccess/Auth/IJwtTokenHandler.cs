using Medics.Core.Entities;
using Medics.DataAccess.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Medics.DataAccess.Auth;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(UserForCreationDto userDto);
    JwtSecurityToken GenerateAccessToken(ApplicationUser user);//-----
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}