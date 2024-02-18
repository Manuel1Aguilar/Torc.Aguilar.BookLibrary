using AutoMapper;
using Torc.Aguilar.BookLibrary.Core.Entities;
using Torc.Aguilar.BookLibrary.Models.DTOs;

namespace Torc.Aguilar.BookLibrary.API.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookGridModel>()
                .ForMember(
                dest => dest.Authors,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                ).ReverseMap();
        }
    }
}
