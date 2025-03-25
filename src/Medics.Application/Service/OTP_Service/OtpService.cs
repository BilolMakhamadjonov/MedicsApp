using Medics.Application.Common;
using Medics.Core.Entities;
using Medics.DataAccess.Data;
using Medics.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Medics.Application.Service.OTP_Service;

public class OtpService : IOtpService
{
    private readonly AppDbContext _context;
    private readonly ICustomEmailSender _emailSender; // Email jo‘natish xizmati

    public OtpService(AppDbContext context, ICustomEmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    public async Task GenerateAndSendOtpAsync(Guid userId, string email)
    {
        var otpCode = new OtpCode
        {
            UserId = userId.ToString(),
            Code = new Random().Next(100000, 999999).ToString(),
            ExpiryTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };

        _context.OtpCodes.Add(otpCode);
        await _context.SaveChangesAsync();

        // ✅ OTP ni foydalanuvchiga jo‘natish (email yoki SMS)
        await _emailSender.SendEmailAsync(email, "Verification Code", $"Your OTP code is: {otpCode.Code}");
    }

    public async Task<bool> VerifyOtpAsync(Guid userId, string code)
    {
        var otp = await _context.OtpCodes
            .Where(o => o.UserId == userId.ToString() && o.Code == code && !o.IsUsed && o.ExpiryTime > DateTime.UtcNow)
            .FirstOrDefaultAsync();

        if (otp == null) return false;

        otp.IsUsed = true;
        await _context.SaveChangesAsync();
        return true;
    }
}