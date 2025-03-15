using Medics.Core.Entities.Enum.User;

namespace Medics.Application.DtoModels.User;

public class UserCreateDTO
{
    public string FullName { get; set; }
    public float Balance { get; set; } = 0;
    public UserRole Role { get; set; } = UserRole.Patient;
    public UserGender Gender { get; set; }
}
