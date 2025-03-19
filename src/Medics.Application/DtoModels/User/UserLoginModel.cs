using Medics.Core.Entities.Enum.User;

namespace Medics.Application.DtoModels.User;

public class UserLoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}