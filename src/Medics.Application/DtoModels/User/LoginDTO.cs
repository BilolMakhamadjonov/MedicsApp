using System.ComponentModel.DataAnnotations;

namespace Medics.Application.DtoModels.User;

public class LoginDTO
{
    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Noto‘g‘ri email formati.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parol majburiy.")]
    public string Password { get; set; }
}
