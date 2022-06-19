using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoserBlog.Application.Contracts.Persistence;
using MoserBlog.Persistence.Repositories;

namespace MoserBlog.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopmentEnv)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(isDevelopmentEnv
                    ? configuration.GetConnectionString("DefaultConnection")
                    : Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING")));


        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IBlogEntryRepository, BlogEntryRepository>();


        return services;
    }
}
