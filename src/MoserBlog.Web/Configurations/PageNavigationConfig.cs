namespace MoserBlog.Web.Configurations;

public class PageNavigationConfig
{
    public string DefaultRouteUrl { get; set; } = string.Empty;
    public List<NavigationItem> NavigationItems { get; set; } = new();
}

public class NavigationItem
{
    public string Title { get; set; } = string.Empty;
    public string RouteUrl { get; set; } = string.Empty;
    public List<string> AlternativeRouteUrls { get; set; } = new();
    public bool IsActive { get; set; } = true;
}
