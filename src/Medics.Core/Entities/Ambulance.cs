using Medics.Core.Comman;

namespace Medics.Core.Entities;

public class Ambulance : BaseEntity
{
    public Geolocation ClientLocation { get; set; }
    public Geolocation AmbulanceLocation { get; set; }
}
