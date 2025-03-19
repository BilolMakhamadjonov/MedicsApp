using AutoMapper;
using Medics.Application.DtoModels.VideoCall;
using Medics.Core.Entities;

namespace Medics.Application.AutoMapping;

public class VideoCallMapping : Profile
{
    public VideoCallMapping()
    {
        CreateMap<VideoCallCreateDTO, VideoCall>();
        CreateMap<VideoCallUpdateDTO, VideoCall>().ReverseMap();
        CreateMap<VideoCall, VideoCallResponceDTO>();
        ///
    }
}