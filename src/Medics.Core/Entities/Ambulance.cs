using Medics.Core.Abstraction;

namespace Medics.Core.Entities;

public class Ambulance : BaseEntity
{
    public Geolocation ClientLocation { get; set; }
    public Geolocation AmbulanceLocation { get; set; }
}
