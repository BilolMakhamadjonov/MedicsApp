using AutoMapper;
using Medics.Application.DtoModels.Ambulance;
using Medics.Application.DtoModels.Appointment;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class AmbulanceMapping : Profile
{
    public AmbulanceMapping()
    {
        CreateMap<AmbulanceCreateDTO, Ambulance>();
        CreateMap<AmbulanceUpdateDTO, Ambulance>().ReverseMap();
        CreateMap<Ambulance, AmbulanceResponseDTO>();
        ///
    }
}