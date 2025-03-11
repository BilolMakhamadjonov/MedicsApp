using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class VideoCall : BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Doctor Doctor{ get; set; }
    public Guid DoctorId { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

}
