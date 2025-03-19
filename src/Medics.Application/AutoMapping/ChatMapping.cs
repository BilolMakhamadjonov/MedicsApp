using AutoMapper;
using Medics.Application.DtoModels.Chat;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class ChatMapping : Profile
{
    public ChatMapping()
    {
        CreateMap<ChatCreateDTO, Chat>();
        CreateMap<ChatUpdateDTO, Chat>().ReverseMap();
        CreateMap<Chat, ChatResponseDTO>();
        ///
    }
}