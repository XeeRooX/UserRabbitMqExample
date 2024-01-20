using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UserRabbitMqExample.Producer.Models;
using UserRabbitMqExample.Producer.Services;
using UserRabbitMqExample.Producer.RabbitMQ;

namespace UserRabbitMqExample.Producer.Extensions
{
    public static class RegisterCustomServicesExtension
    {
        public static void RegisterCustomServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var config = builder.Configuration;

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Program));
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCommandsService, UserCommandsService>();
            services.AddScoped<IUserQueriesService, UserQueriesService>();
            services.AddScoped<IMessageProducer, MessageProducer>();
        }
    }
}
