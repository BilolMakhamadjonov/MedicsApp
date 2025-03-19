using AutoMapper;
using Medics.Application.DtoModels.Doctor;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<DoctorCreateDTO, Doctor>();
        CreateMap<DoctorUpdateDTO, Doctor>().ReverseMap();
        CreateMap<Doctor, DoctorResponseDTO>();
    }
}