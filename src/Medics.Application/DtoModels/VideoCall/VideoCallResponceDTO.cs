
namespace Medics.Application.DtoModels.VideoCall;

public class VideoCallResponceDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DoctorId { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
