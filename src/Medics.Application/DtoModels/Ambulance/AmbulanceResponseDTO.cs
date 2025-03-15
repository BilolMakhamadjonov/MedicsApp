using Medics.Application.DtoModels.Geolocation;

namespace Medics.Application.DtoModels.Ambulance;

public class AmbulanceResponseDTO
{
    public Guid Id { get; set; }
    public GeolocationResponseDTO ClientLocation { get; set; }
    public GeolocationResponseDTO AmbulanceLocation { get; set; }
}