using AutoMapper;
using PassengerApi.Models;
using PassengerApi.Models.Dtos;

namespace PassengerApi
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Passenger, PassengerDto>().ReverseMap();
            CreateMap<Passenger, PassengerCreateDto>().ReverseMap();
            CreateMap<Passenger,PassengerUpdateDto>().ReverseMap();
        }
    }
}
