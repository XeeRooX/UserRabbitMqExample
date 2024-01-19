using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public interface IUserQueriesService
    {
        Task<GetUserOutDto> Get(GetUserInDto user);
    }
}
