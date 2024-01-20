using Microsoft.EntityFrameworkCore;

namespace UserRabbitMqExample.Producer.Models
{
    public class InitializationDb
    {
        public static void Migrate(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                if (dbContext != null && dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
