using AutoMapper;
using Demo.AspNetWebApi.Dto;
using Demo.DataLibrary.Models;

namespace Demo.AspNetWebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Films, FilmDto>();
            //CreateMap<FilmDto, Films>();

            CreateMap<Film, FilmDto>().ReverseMap();
        }
    }
}
