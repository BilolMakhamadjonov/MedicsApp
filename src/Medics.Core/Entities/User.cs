using Medics.Core.Comman;
using Medics.Core.Entities.Enum.User;
using Microsoft.AspNetCore.Identity;

namespace Medics.Core.Entities;

public class User : IdentityUser<Guid>, IAuditedEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public float Balance { get; set; } = 0;
    public UserRole Role { get; set; } = UserRole.Patient;
    public UserGender Gender { get; set; }
    public bool? IsVerified { get; set; } = false;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }

    public ICollection<AppointmentPayment> Appointments { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Chat> Chats { get; set; }

    // Audit
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
