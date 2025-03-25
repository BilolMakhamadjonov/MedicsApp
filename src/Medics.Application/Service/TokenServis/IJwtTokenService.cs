using Medics.Core.Entities;

namespace Medics.Application.Service.TokenServis;

public interface IJwtTokenService
{
    Task<string> GenerateToken(User user);
    string GenerateRefreshToken();

}
