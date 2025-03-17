using Medics.Core.Entities.Enum.User;

namespace Medics.Application.Extensions;

public static class RoleExtensions
{
    public static string ToIdentityRole(this UserRole role)
    {
        return role switch
        {
            UserRole.Patient => "Patient",
            UserRole.Doctor => "Doctor",
            UserRole.Admin => "Admin",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}