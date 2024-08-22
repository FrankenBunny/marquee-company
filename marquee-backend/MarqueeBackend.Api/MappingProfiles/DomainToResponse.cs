using AutoMapper;
using dotnetFullstack.Entities.DbSet;
using dotnetFullstack.Entities.Dtos.Requests;

namespace dotnetFullstack.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Part, CreateRentablePartRequest>()
            .ForMember(dest => dest.PartTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PartNote, opt => opt.MapFrom(src => src.Note));

        CreateMap<Part, UpdateRentablePartRequest>()
            .ForMember(dest => dest.PartTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PartNote, opt => opt.MapFrom(src => src.Note));
    }
}
