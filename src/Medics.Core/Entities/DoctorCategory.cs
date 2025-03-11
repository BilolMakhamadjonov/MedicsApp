using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class DoctorCategory : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
