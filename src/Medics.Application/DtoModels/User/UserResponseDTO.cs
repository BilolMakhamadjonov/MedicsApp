using Medics.Core.Entities.Enum.User;

namespace Medics.Application.DtoModels.User;

public class UserResponseDTO
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public float Balance { get; set; }
    public UserRole Role { get; set; }
    public UserGender Gender { get; set; }
}
