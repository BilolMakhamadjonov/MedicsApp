using Medics.Core.Entities.Enum.User;
using System.ComponentModel.DataAnnotations;

namespace Medics.Application.DtoModels.User;

public class RegisterDTO
{
    [Required(ErrorMessage = "Ism majburiy.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Ism uzunligi 2 dan 50 gacha bo‘lishi kerak.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Noto‘g‘ri email formati.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Parol majburiy.")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "Parol uzunligi 8 dan 20 gacha bo‘lishi kerak.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role tanlash majburiy.")]
    public UserRole Role { get; set; }
}