namespace Medics.Application.DtoModels.Chat;

public class ChatRequestModel
{
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public string Message { get; set; }
}
