namespace MoserBlog.Web.Configurations;

public static class ConfigurationServiceRegistration
{
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BlogMetaDataConfiguration>(
            configuration.GetSection(nameof(BlogMetaDataConfiguration)));

        return services;
    }
}
