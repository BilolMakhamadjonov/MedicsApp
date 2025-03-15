using Medics.Core.Comman;
using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class Chat : BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid DoctorId { get; set; }
    public string Message { get; set; }
    public bool IsReaded { get; set; }
    public VideoCall VideoCall { get; set; }
    public Guid VideoCallId { get; set;}
}
