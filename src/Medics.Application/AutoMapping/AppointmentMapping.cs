using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class AppointmentMapping : Profile
{
    public AppointmentMapping()
    {
        CreateMap<AppointmentCreateDTO, Appointment>();
        CreateMap<AppointmentUpdateDTO, Appointment>().ReverseMap();
        CreateMap<Appointment, AppointmentResponseDTO>().ReverseMap();
        ///
    }
}