namespace Medics.Application.DtoModels.Ambulance;

public class AmbulanceCreateDTO
{
    public Guid ClientLocationId { get; set; }
    public Guid AmbulanceLocationId { get; set; }
}