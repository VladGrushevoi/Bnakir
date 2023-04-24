using System.Data;
using System.Xml.Serialization;
using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.DeleteUserFeature;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, User>()
            .ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => Guid.Parse(src.Id)));
        CreateMap<User, DeleteUserResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.DeletedAt, opt 
                => opt.MapFrom(_ => DateOnly.FromDateTime(DateTime.Now)))
            .ForMember(dest => dest.FullName, opt 
            => opt.MapFrom(src => $"{src.Name} {src.Surname}"));
    }
}