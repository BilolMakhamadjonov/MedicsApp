namespace Medics.Application.DtoModels.Geolocation;

public class GeolocationUpdateDTO
{
    public double? xCordinate { get; set; }
    public double? yCordinate { get; set; }
}

public class UpdateGeolocationResponseDTO : BaseResponseDTO { }
