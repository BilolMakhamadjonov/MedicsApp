using Medics.Core.Entities.Enum.User;

namespace Medics.Application.DtoModels.User;

public class UserRegisterModel
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }
}