using Microsoft.EntityFrameworkCore;
using UserRabbitMqExample.Producer.Models;

namespace UserRabbitMqExample.Producer.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> AddAsync(User user)
        {
            var result = await _dbContext.Users.AddAsync(user);
            return result.Entity;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user!;
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public bool IsExistsById(int id)
        {
            return _dbContext.Users.Find(id) != null!;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var result = _dbContext.Update(user);
            return result.Entity;
        }
    }
}
