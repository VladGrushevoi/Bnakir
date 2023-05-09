using AutoMapper;
using KozakBank.Domain.Entities;

namespace KozakBank.Application.Features.UserFeatures.GetUsersByProperties;

public sealed class GetUsersByPropertiesMapper : Profile
{
    public GetUsersByPropertiesMapper()
    {
        CreateMap<GetUsersByPropertiesRequest, User>()
            .ForMember(dest => dest.Name, opt 
            => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Surname, opt 
                => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Phone, opt 
                => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Country, opt 
                => opt.MapFrom(src => src.CountryLiving));
        CreateMap<IEnumerable<User>, GetUsersByPropertiesResponse>()
            .ForMember(dest => dest.Data, opt 
            => opt.MapFrom(src => src))
            .ForMember(dest => dest.Count, opt 
            => opt.MapFrom(src => src.Count()));
    }
}