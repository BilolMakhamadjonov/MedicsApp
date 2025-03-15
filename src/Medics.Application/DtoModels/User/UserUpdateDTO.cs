using Medics.Core.Entities.Enum.User;

namespace Medics.Application.DtoModels.User;

public class UserUpdateDTO
{
    public string FullName { get; set; }
    public float Balance { get; set; } = 0;
    public UserGender Gender { get; set; }
}
