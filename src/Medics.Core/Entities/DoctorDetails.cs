using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class DoctorDetails : BaseEntity
{
    public string UserName { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public string About { get; set; }
    public DateTime StartWorking { get; set; }
    public DateTime EndWorking { get; set; }

    public double AverageStars { get; set; } = 4.7; // To'g'ri tip: `double`
}
