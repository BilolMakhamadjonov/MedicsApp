namespace Medics.Application.DtoModels.Chat;

public class ChatCreateDTO
{
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public string Message { get; set; }
    public Guid VideoCallId { get; set; }
}
