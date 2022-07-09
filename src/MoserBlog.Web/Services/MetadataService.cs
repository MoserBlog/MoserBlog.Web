using Microsoft.Extensions.Options;
using MoserBlog.Web.Configurations;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web.Services;

public class MetadataService : IMetadataService
{
    private readonly ILogger<BlogService> _logger;
    private readonly IOptions<BlogMetaDataConfig> _blogMetaDataConfig;
    private readonly IOptions<SeoConfig> _seoConfig;

    public MetadataService(ILogger<BlogService> logger,
        IOptions<BlogMetaDataConfig> blogMetaDataConfig,
        IOptions<SeoConfig> seoConfig)
    {
        _logger = logger;
        _blogMetaDataConfig = blogMetaDataConfig;
        _seoConfig = seoConfig;
    }

    public string GetPageTitle(string? pageTitle)
    {
        return $"{(string.IsNullOrEmpty(pageTitle) ? "" : $"{pageTitle} - ")}{_seoConfig.Value.PageTitleValue}";
    }

    public string GetPageDescription(string? pageDescription)
    {
        return _blogMetaDataConfig.Value.Name ?? "";
    }

    public string GetRobotsValue()
    {
        return _seoConfig.Value.IndexAndfollow
            ? "INDEX;FOLLOW"
            : "NOINDEX,NOFOLLOW";
    }
}
