namespace MoserBlog.Web.Configurations;

public class PageNavigationConfig
{
    public string DefaultRouteUrl { get; init; } = string.Empty;
    public List<NavigationItem> NavigationItems { get; init; } = new();
}

public class NavigationItem
{
    public string Title { get; init; } = string.Empty;
    public string RouteUrl { get; init; } = string.Empty;
    public List<string> AlternativeRouteUrls { get; init; } = new();
    public bool IsActive { get; init; } = true;
}
