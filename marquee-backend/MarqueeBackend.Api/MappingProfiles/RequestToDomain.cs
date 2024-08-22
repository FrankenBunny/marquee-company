using AutoMapper;
using dotnetFullstack.Entities.DbSet;
using dotnetFullstack.Entities.Dtos.Requests;

namespace dotnetFullstack.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateRentablePartRequest, Part>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PartTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.PartTitle))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(opt => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(opt => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateRentablePartRequest, Part>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PartTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.PartNote))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
