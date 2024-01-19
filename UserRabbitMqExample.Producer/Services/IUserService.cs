using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public interface IUserService
    {
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Delete(int id);
        Task<User> Get(int id);
    }
}
