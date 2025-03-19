using AutoMapper;
using Medics.Application.DtoModels.AppointmentPayment;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class AppointmentPaymentMapping : Profile
{
    public AppointmentPaymentMapping()
    {
        CreateMap<AppointmentPaymentCreateDTO, AppointmentPayment>();
        CreateMap<AppointmentPaymentUpdateDTO, AppointmentPayment>().ReverseMap();
        CreateMap<AppointmentPayment, AppointmentPaymentResponseDTO>();
        ///
    }
}