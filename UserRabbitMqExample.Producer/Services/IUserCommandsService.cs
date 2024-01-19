using UserRabbitMqExample.Producer.Dtos;
using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public interface IUserCommandsService
    {
        Task<GetUserOutDto> Add(AddUserDto user);
        Task<GetUserOutDto> Update(EditUserDto user);
        Task<GetUserOutDto> Delete(GetUserInDto user);
    }
}
