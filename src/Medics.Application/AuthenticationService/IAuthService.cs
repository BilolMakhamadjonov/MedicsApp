using Medics.Application.DtoModels.User;
using Medics.Application.Service.OTP_Service;
using Medics.Core.Comman;

namespace Medics.Application.AuthenticationService;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(string email, string password);
    Task<AuthResponse> RefreshTokenAsync(string refreshToken);
    Task<Guid> RegisterAsync(string fullName, string email);
    Task<bool> VerifyOtpAsync(Guid userId, string code);
}
