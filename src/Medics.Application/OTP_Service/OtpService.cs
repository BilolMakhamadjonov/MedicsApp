using Medics.Core.Entities;
using Medics.DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Medics.Application.OTP_Service;

public class OtpService : IOtpService
{
    private readonly AppDbContext _context;
    private readonly ICustomEmailSender _emailSender;
    private readonly UserManager<IdentityUser> _userManager;

    public OtpService(AppDbContext context, ICustomEmailSender emailSender, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _emailSender = emailSender;
        _userManager = userManager;
    }

    public async Task GenerateAndSendOtpAsync(string userId, string email)
    {
        var otpCode = new OtpCode
        {
            UserId = userId,
            Code = new Random().Next(100000, 999999).ToString(),
            ExpiryTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };

        _context.OtpCodes.Add(otpCode);
        await _context.SaveChangesAsync();

        await _emailSender.SendEmailAsync(email, "Verification Code", $"Your OTP code is: {otpCode.Code}");
    }

    public async Task<bool> VerifyOtpAsync(string userId, string code)
    {
        var otp = await _context.OtpCodes
            .Where(o => o.UserId == userId && o.Code == code && !o.IsUsed && o.ExpiryTime > DateTime.UtcNow)
            .FirstOrDefaultAsync();

        if (otp == null) return false;

        otp.IsUsed = true;
        await _context.SaveChangesAsync();
        return true;
    }
}