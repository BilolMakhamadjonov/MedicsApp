using Medics.Core.Entities.Enum.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medics.DataAccess.Auth;

public class UserForCreationDto
{
    [Required(ErrorMessage = "Foydalanuvchi nomini kiritish shart.")]
    [StringLength(15, MinimumLength = 2, ErrorMessage = "Ism uzunligi kamida 2 va maksimal 15 ta belgidan iborat bo'lishi kerak.")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Ism faqat harflar va bo'sh joylardan iborat bo'lishi kerak.")]

    public required string Name { get; set; }

    [Required(ErrorMessage = "Email manzilini kiritish shart.")]
    [EmailAddress(ErrorMessage = "Email manzil noto'g'ri formatda.")]
    public required string Email { get; set; }

    public required string Address { get; set; }

    [Required(ErrorMessage = "Parol kiritilishi shart.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "Parol kamida 8 ta belgidan iborat bo'lishi kerak. Max: 15")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Parol kamida 1 ta kichik harf, 1 ta katta harf, 1 ta belgi va 1 ta raqamdan iborat bo'lishi kerak.")]
    [PasswordPropertyText]
    public required string Password { get; set; }
    public UserRole Role { get; set; }
}
