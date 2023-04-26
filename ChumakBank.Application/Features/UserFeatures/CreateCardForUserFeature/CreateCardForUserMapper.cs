using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.CreateCardForUserFeature;

public sealed class CreateCardForUserMapper : Profile
{
    public CreateCardForUserMapper()
    {
        CreateMap<CreateCardForUserRequest, User>()
            .ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => Guid.Parse(src.UserId)));

        CreateMap<KisaCard, CreateCardForUserResponse>()
            .ForMember(dest => dest.Id, opt 
            => opt.MapFrom(src => src.Id.ToString()));
    }
}