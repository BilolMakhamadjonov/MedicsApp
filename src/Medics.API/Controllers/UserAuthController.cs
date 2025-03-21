using Medics.Application.DtoModels.User;
using Medics.Application.Extensions;
using Medics.Application.OTP_Service;
using Medics.DataAccess.Auth;
using Medics.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medics.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IJwtTokenHandler _jwtTokenHandler;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IOtpService _otpService;
    private readonly UserManager<IdentityUser> _identityUserManager;

    public AuthController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        IJwtTokenHandler jwtTokenHandler,
        RoleManager<IdentityRole> roleManager,
        IOtpService otpService,
        UserManager<IdentityUser> identityUserManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _jwtTokenHandler = jwtTokenHandler;
        _roleManager = roleManager;
        _otpService = otpService;
        _identityUserManager = identityUserManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new ApplicationUser
        {
            UserName = model.Email,  // FullName emas, Email saqlanadi
            Email = model.Email,
            FullName = model.FullName, // Ismni alohida saqlaymiz
            Role = model.Role
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        if (!string.IsNullOrEmpty(user.Role.ToString()) && await _roleManager.RoleExistsAsync(user.Role.ToString()))
        {
            await _userManager.AddToRoleAsync(user, user.Role.ToIdentityRole());
        }

        return Ok(new { message = "User registered successfully" });
    }

    //--------
    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return NotFound("User not found");

        await _otpService.GenerateAndSendOtpAsync(user.Id, email);
        return Ok("OTP sent successfully");
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpCommand command)
    {
        var user = await _userManager.FindByIdAsync(command.UserId);
        if (user == null) return NotFound("User not found");

        var result = await _otpService.VerifyOtpAsync(command.UserId, command.Code);
        if (!result) return BadRequest("Invalid or expired OTP code");

        return Ok("User successfully verified");
    }
    public class VerifyOtpCommand
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
    //----------

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized(new { message = "Email yoki parol noto‘g‘ri" });

            if (!user.EmailConfirmed)
                return Unauthorized(new { message = "Email tasdiqlanmagan!" });

            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.UtcNow)
                return Unauthorized(new { message = "Foydalanuvchi bloklangan!" });

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
                return Unauthorized(new { message = "Email yoki parol noto‘g‘ri" });

            var token = _jwtTokenHandler.GenerateAccessToken(user);
            var refreshToken = _jwtTokenHandler.GenerateRefreshToken();

            // RefreshToken saqlanadi
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                expiration = token.ValidTo,
                User = user
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    private string GenerateJwtToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}