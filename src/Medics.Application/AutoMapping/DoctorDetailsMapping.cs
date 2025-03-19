using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Application.DtoModels.DoctorDetails;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class DoctorDetailstMapping : Profile
{
    public DoctorDetailstMapping()
    {
        CreateMap<DoctorDetailsCreateDTO, DoctorDetails>();
        CreateMap<DoctorDetailsUpdateDTO, DoctorDetails>().ReverseMap();
        CreateMap<DoctorDetails, DoctorDetailsResponseDTO>();
        ///
    }
}