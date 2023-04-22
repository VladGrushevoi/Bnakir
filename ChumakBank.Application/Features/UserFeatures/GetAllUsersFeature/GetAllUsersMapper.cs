using AutoMapper;
using ChumakBank.Domain.Entities;

namespace ChumakBank.Application.Features.UserFeatures.GetAllUsersFeature;

public sealed class GetAllUsersMapper : Profile
{
    public GetAllUsersMapper()
    {
        CreateMap<IEnumerable<User>, GetAllUsersResponse>()
            .ForMember(dest => dest.Data, opt =>
                opt.MapFrom(src => src.ToList()))
            .ForMember(dest => dest.Total, opt =>
                opt.MapFrom(src => src.Count()));
    }
}