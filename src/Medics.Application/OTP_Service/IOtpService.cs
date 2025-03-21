namespace Medics.Application.OTP_Service;

public interface IOtpService
{
    Task GenerateAndSendOtpAsync(string userId, string email);
    Task<bool> VerifyOtpAsync(string userId, string code);
}
