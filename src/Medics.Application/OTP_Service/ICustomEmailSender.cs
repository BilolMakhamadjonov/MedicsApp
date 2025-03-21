namespace Medics.Application.OTP_Service;

public interface ICustomEmailSender
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
