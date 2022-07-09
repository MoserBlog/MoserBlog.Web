namespace MoserBlog.Web.Configurations;

public static class ConfigurationServiceRegistration
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BlogMetaDataConfig>(configuration.GetSection(nameof(BlogMetaDataConfig)));
        services.Configure<SeoConfig>(configuration.GetSection(nameof(SeoConfig)));

        return services;
    }
}
