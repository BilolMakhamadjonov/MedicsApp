using AutoMapper;
using Medics.Core.Entities;
using Medics.Application.DtoModels;
using Medics.Application.DtoModels.User;
using Medics.Application.DtoModels.Appointment;

namespace Medics.Application.AutoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mapping
        CreateMap<User, UserResponseDTO>().ReverseMap();
        CreateMap<User, UserCreateDTO>().ReverseMap();
        CreateMap<User, UserUpdateDTO>().ReverseMap();

        // Appointment mapping
        CreateMap<AppointmentPayment, AppointmentResponseDTO>().ReverseMap();
        CreateMap<AppointmentPayment, CreateAppointmentDto>().ReverseMap();
        CreateMap<AppointmentPayment, UpdateAppointmentDto>().ReverseMap();

        // Pharmacy mapping
        CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
        CreateMap<Pharmacy, CreatePharmacyDto>().ReverseMap();
        CreateMap<Pharmacy, UpdatePharmacyDto>().ReverseMap();

        // Payment mapping
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, CreatePaymentDto>().ReverseMap();
        CreateMap<Payment, UpdatePaymentDto>().ReverseMap();

        // Geolocation mapping
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<Location, CreateLocationDto>().ReverseMap();
        CreateMap<Location, UpdateLocationDto>().ReverseMap();

        // Chat mapping
        CreateMap<Chat, ChatDto>().ReverseMap();
        CreateMap<Chat, CreateChatDto>().ReverseMap();
        CreateMap<Chat, UpdateChatDto>().ReverseMap();

        // Video Call mapping
        CreateMap<VideoCall, VideoCallDto>().ReverseMap();
        CreateMap<VideoCall, CreateVideoCallDto>().ReverseMap();
        CreateMap<VideoCall, UpdateVideoCallDto>().ReverseMap();
    }
}