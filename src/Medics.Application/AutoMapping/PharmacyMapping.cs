using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Application.DtoModels.Pharmacy;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class PharmacyMapping : Profile
{
    public PharmacyMapping()
    {
        CreateMap<PharmacyCreateDTO, Pharmacy>();
        CreateMap<PharmacyUpdateDTO, Pharmacy>().ReverseMap();
        CreateMap<Pharmacy, PharmacyResponseDTO>();
        ///
    }
}