using System.ComponentModel.DataAnnotations;

namespace Medics.Application.DtoModels.User;

public class OtpVerificationDTO
{
    public Guid UserId { get; set; }
    public string Code { get; set; }
}