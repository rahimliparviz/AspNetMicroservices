using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Repositories;
using Ordering.Application.Contracts.Services;
using Ordering.Application.Models;
using Ordering.Infrastructure.Mail;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repositories;

namespace Ordering.Infrastructure
{
    public static class InfrastructureDependencyInjections
    {
        public static IServiceCollection AddInfrastructureDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));
            // configuration.GetConnectionString("OrderingConnectionString"))
            // services.AddScoped<IDbConnection>(cn => new NpgsqlConnection
            //     ("Server=localhost;Port=5433;Database=OrderDb;User Id=admin;Password=admin1234;"));
            // services.AddDbContext<OrderContext>(opts => {
            //     opts.EnableDetailedErrors();
            //     opts.UseNpgsql(configuration.GetConnectionString("OrderingConnectionString"));
            // });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}