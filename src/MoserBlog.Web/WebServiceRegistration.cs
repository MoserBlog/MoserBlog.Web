using MoserBlog.Web.Services;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web;

public static class WebServiceRegistration
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();

        return services;
    }
}
