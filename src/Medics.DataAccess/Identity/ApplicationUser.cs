using Medics.Core.Entities.Enum.User;
using Microsoft.AspNetCore.Identity;

namespace Medics.DataAccess.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public UserRole Role { get; set; } = UserRole.Patient; // Default rol: Patient
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
