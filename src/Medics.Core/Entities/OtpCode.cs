using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class OtpCode : BaseEntity
{
    public string UserId { get; set; }
    public string Code { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsUsed { get; set; } = false;

}