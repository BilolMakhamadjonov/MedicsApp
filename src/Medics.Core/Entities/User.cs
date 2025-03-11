using Medics.Core.Abstraction;
using Medics.Core.Entities.Enum.User;

namespace Medics.Core.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public float Balance { get; set; } = 0;
    public UserRole Role { get; set; } = UserRole.Patient;
    public UserGender Gender { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Chat> Chats { get; set; }
}
