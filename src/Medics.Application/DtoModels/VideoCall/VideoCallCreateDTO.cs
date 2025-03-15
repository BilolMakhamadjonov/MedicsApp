namespace Medics.Application.DtoModels.VideoCall;

public class VideoCallCreateDTO
{
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
