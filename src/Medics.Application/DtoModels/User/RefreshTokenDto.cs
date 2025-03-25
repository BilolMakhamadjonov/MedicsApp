using Medics.Application.Service.OTP_Service;

namespace Medics.Application.DtoModels.User;

public class RefreshTokenDto : AuthResponse
{
    public string RefreshToken { get; set; }
}