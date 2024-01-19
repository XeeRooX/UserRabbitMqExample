using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public interface IUserService
    {
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(int id);
        Task<User?> GetAsync(int id);
        bool IsExistsById(int id);
    }
}
