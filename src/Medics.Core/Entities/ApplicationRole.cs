using Medics.Core.Entities.Enum.User;
using Microsoft.AspNetCore.Identity;

namespace Medics.Core.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public int RoleType { get; set; }
    public ApplicationRole() : base() { }

    public ApplicationRole(UserRole role) : base(role.ToString())
    {
        Id = Guid.NewGuid();
        RoleType = (int)role;
    }
}
