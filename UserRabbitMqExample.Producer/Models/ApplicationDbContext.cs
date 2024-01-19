using Microsoft.EntityFrameworkCore;

namespace UserRabbitMqExample.Producer.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {     
        }
    }
}
