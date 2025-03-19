using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Application.DtoModels.PersonalCabinet;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class PersonalCabinetMapping : Profile
{
    public PersonalCabinetMapping()
    {
        CreateMap<PersonalCabinetCreateDTO, PersonalCabinet>();
        CreateMap<PersonalCabinetUpdateDTO, PersonalCabinet>().ReverseMap();
        CreateMap<PersonalCabinet, PersonalCabinetResponseDTO>();
        ///
    }
}
