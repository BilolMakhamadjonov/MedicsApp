using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class DoctorDetails : BaseEntity
{
    public string UserName { get; set; }
    public string AvarageStars { get; set; }
    public string About { get; set; }
    public DateTime StartWorking { get; set; }
    public DateTime EndWorking { get; set;}
    public Chat Chat { get; set; }
    public Guid ChatId { get; set; }
}
