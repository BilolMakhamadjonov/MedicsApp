using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace Medics.Application.Common;

public class EmailSender : ICustomEmailSender
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _emailFrom;
    private readonly string _emailPassword;
    public EmailSender(IConfiguration configuration)
    {
        _smtpServer = configuration["EmailSettings:SmtpServer"] ?? throw new ArgumentNullException("SMTP server not configured.");
        _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"] ?? "587");
        _emailFrom = configuration["EmailSettings:EmailFrom"] ?? throw new ArgumentNullException("Sender email not configured.");
        _emailPassword = configuration["EmailSettings:EmailPassword"] ?? throw new ArgumentNullException("Email password not configured.");
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using var client = new SmtpClient(_smtpServer, _smtpPort)
        {
            Credentials = new NetworkCredential(_emailFrom, _emailPassword),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailFrom),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await client.SendMailAsync(mailMessage);
    }
}
