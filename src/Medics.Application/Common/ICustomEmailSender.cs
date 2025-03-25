namespace Medics.Application.Common;

public interface ICustomEmailSender
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
