using AutoMapper;
using PassangerApi.Models;
using PassangerApi.Models.Dtos;

namespace PassangerApi
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Passanger, PassangerDto>().ReverseMap();
            CreateMap<Passanger, PassangerCreateDto>().ReverseMap();
            CreateMap<Passanger,PassangerUpdateDto>().ReverseMap();
        }
    }
}
