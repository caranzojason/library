using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                 .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
                 .ForMember(dest => dest.IsCheckedOut, opt => opt.MapFrom(src => src.IsCheckedOut))
                 .ReverseMap();
         }
    }
}
