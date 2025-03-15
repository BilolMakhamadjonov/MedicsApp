namespace Medics.Application.DtoModels.Chat;

public class ChatResponseDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public string Message { get; set; }
    public bool IsReaded { get; set; }
    public Guid VideoCallId { get; set; }
}
