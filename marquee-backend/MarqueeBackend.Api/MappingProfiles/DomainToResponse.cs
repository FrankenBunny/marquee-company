using AutoMapper;
using MarqueeBackend.Entities.DbSet;
using MarqueeBackend.Entities.Dtos.Requests;
using MarqueeBackend.Entities.Dtos.Response;

namespace MarqueeBackend.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Category, CategoryResponse>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(
                dest => dest.CategoryDescription,
                opt => opt.MapFrom(src => src.Description)
            );

        CreateMap<Part, PartResponse>()
            .ForMember(dest => dest.PartTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PartNote, opt => opt.MapFrom(src => src.Note));

        CreateMap<Rentable, RentableResponse>()
            .ForMember(dest => dest.RentableTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.RentableNote, opt => opt.MapFrom(src => src.Note))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
    }
}
