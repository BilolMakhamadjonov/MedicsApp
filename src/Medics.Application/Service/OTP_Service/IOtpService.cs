namespace Medics.Application.Service.OTP_Service;

public interface IOtpService
{
    Task GenerateAndSendOtpAsync(Guid userId, string email);
    Task<bool> VerifyOtpAsync(Guid userId, string code);
}