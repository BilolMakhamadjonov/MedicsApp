namespace Medics.Application.Service.OTP_Service;

public class AuthResponse
{
    public string AccessToken { get; set; }
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; }
}
