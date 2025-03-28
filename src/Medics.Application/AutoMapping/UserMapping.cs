﻿using AutoMapper;
using Medics.Application.DtoModels.Appointment;
using Medics.Application.DtoModels.User;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserCreateDTO, User>();
        CreateMap<UserUpdateDTO, User>().ReverseMap();
        CreateMap<LoginDTO, User>();
        CreateMap<RegisterDTO, User>();
        ///
    }
}