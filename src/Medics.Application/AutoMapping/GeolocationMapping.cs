using AutoMapper;
using Medics.Application.DtoModels.Geolocation;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class GeolocationMapping : Profile
{
    public GeolocationMapping()
    {
        CreateMap<GeolocationCreateDTO, Geolocation>();
        CreateMap<GeolocationUpdateDTO, Geolocation>().ReverseMap();
        CreateMap<Geolocation, GeolocationResponseDTO>();
        ///
    }
}