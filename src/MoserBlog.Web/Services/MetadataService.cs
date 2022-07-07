using System.Text;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web.Services;

public class MetadataService : IMetadataService
{
    private readonly ILogger<BlogService> _logger;
    private readonly IConfiguration _configuration;

    public MetadataService(ILogger<BlogService> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public string GetPageTitle(string? pageTitle)
    {
        return $"{(string.IsNullOrEmpty(pageTitle) ? "" : $"{pageTitle} - ")}{_configuration["BlogMetaDataConfiguration:Name"]}";
    }

    public string GetPageDescription(string? pageDescription)
    {
        return _configuration["BlogMetaDataConfiguration:Name"];
    }

    public string GetRobotsValue()
    {
        if (bool.TryParse(_configuration["IndexAndFollow"], out var indexAndFollow) && indexAndFollow) {
            return "INDEX;FOLLOW";
        }

        return "NOINDEX,NOFOLLOW";
    }
}
