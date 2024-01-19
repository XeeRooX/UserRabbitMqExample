using AutoMapper;
using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.MappingConfiguratuions
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<AddUserDto, User>();
            CreateMap<User, GetUserOutDto>();
            CreateMap<EditUserDto, User>();
        }
    }
}
