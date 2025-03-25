using Medics.Application.Service.OTP_Service;
using Medics.Application.Service.TokenServis;
using Medics.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Medics.Application.AuthenticationService;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IOtpService _otpService;

    public AuthService(UserManager<User> userManager, IJwtTokenService jwtTokenService, IOtpService otpService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
        _otpService = otpService;
    }

    public async Task<AuthResponse> LoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            throw new UnauthorizedAccessException("Username or password is incorrect");

        var accessToken = await _jwtTokenService.GenerateToken(user);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            Expiration = DateTime.UtcNow.AddMinutes(30),
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new UnauthorizedAccessException("Invalid refresh token");

        var accessToken = await _jwtTokenService.GenerateToken(user);
        var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            Expiration = DateTime.UtcNow.AddMinutes(30),
            RefreshToken = newRefreshToken
        };
    }

    public async Task<Guid> RegisterAsync(string fullName, string email)
    {
        var user = new User
        {
            FullName = fullName,
            Email = email
        };

        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"User registration failed: {errors}");
        }

        await _otpService.GenerateAndSendOtpAsync(user.Id, user.Email);
        return user.Id;
    }

    public async Task<bool> VerifyOtpAsync(Guid userId, string code)
    {
        var isValid = await _otpService.VerifyOtpAsync(userId, code);
        if (!isValid) return false;

        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null) throw new Exception("User not found");

        user.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
        return true;
    }
}