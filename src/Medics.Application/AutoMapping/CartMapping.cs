using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Application.DtoModels.Cart;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class CartMapping : Profile
{
    public CartMapping()
    {
        CreateMap<CartCreateDTO, Cart>();
        CreateMap<CartUpdateDTO, Cart>().ReverseMap();
        CreateMap<Cart, CartResponseDTO>();
        ///
    }
}