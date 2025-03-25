using Medics.Application.AuthenticationService;
using Medics.Application.DtoModels.User;
using Medics.Core.Comman;
using Microsoft.AspNetCore.Mvc;

namespace Medics.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto.Name, registerDto.Email);
        return Ok(new { UserId = result, Message = "Verification code sent to your email" });
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] OtpVerificationDTO verifyOtpDto)
    {
        var result = await _authService.VerifyOtpAsync(verifyOtpDto.UserId, verifyOtpDto.Code);
        if (!result) return BadRequest(ApiResult.Failure(Error.BadRequest, "OTP noto‘g‘ri yoki muddati o‘tgan"));
        //if (!result) return BadRequest("Invalid or expired OTP code");

        return Ok(ApiResult.Success("OTP muvaffaqiyatli tasdiqlandi."));
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        var result = await _authService.LoginAsync(loginDto.Email, loginDto.Password);
        return Ok(result);

        //return Ok(new
        //{
        //    Token = result.Value,
        //    Message = result.SuccessMessage
        //});
    }



    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        var result = await _authService.RefreshTokenAsync(refreshTokenDto.RefreshToken);
        //if (result.IsFailure) return Unauthorized(result);

        return Ok(result);
    }

}