using AutoMapper;
using MarqueeBackend.Entities.DbSet;
using MarqueeBackend.Entities.Dtos.Requests;

namespace MarqueeBackend.Api.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreatePartRequest, Part>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PartTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.PartNote))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(opt => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(opt => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdatePartRequest, Part>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.PartTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.PartNote))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.CategoryTitle))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(opt => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(opt => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.CategoryTitle))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<CreateRentableRequest, Rentable>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.RentableTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.RentableNote))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(opt => 1))
            .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(opt => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UpdateRentableRequest, Rentable>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.RentableTitle))
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.RentableNote))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}
