using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class DoctorCategory : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
