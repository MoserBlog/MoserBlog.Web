using MoserBlog.Web.Services;
using MoserBlog.Web.Services.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MoserBlog.Web;

public static class WebServiceRegistration
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<IMetadataService, MetadataService>();


        services.AddHealthChecks()
            .AddCheck<HealthCheck>(
                "blog_health_check",
                failureStatus: HealthStatus.Degraded
            );

        return services;
    }
}
