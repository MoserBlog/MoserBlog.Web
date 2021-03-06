namespace MoserBlog.Web.Configurations;

public static class ConfigurationServiceRegistration
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();


        services.Configure<BlogMetaDataConfig>(configuration.GetSection(nameof(BlogMetaDataConfig)));
        services.Configure<SeoConfig>(configuration.GetSection(nameof(SeoConfig)));
        services.Configure<PageNavigationConfig>(configuration.GetSection(nameof(PageNavigationConfig)));

        return services;
    }
}
