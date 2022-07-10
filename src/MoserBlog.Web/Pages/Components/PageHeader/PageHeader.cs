using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoserBlog.Web.Configurations;

namespace MoserBlog.Web.Pages.Components.PageHeader;

[ViewComponent]
public class PageHeader : ViewComponent
{
    private List<NavItem> _navigationItems = new();

    private readonly IOptions<PageNavigationConfig> _pageNavigationConfig;

    public PageHeader(IOptions<PageNavigationConfig> pageNavigationConfig)
    {
        _pageNavigationConfig = pageNavigationConfig;
    }

    public IViewComponentResult Invoke()
    {
        _pageNavigationConfig.Value.NavigationItems.ForEach(x => _navigationItems.Add(new(x.Title, x.RouteUrl, x.AlternativeRouteUrls, x.IsActive)));

        var currentRoute = ViewContext.ActionDescriptor.RouteValues.ContainsKey("page")
            ? ViewContext.ActionDescriptor.RouteValues["page"] ?? _pageNavigationConfig.Value.DefaultRouteUrl : _pageNavigationConfig.Value.DefaultRouteUrl;

        _navigationItems
            .Where(
                x => x.RouteUrl.ToLower().Equals(currentRoute.ToLower()) || 
                x.AlternativeRouteUrls.Any(y => y.ToLower().Equals(currentRoute.ToLower())))
            .ToList()
            .ForEach(y => y.IsCurrent = true);

        return View(nameof(PageHeader), _navigationItems.Where(x => x.IsActive).ToList().AsReadOnly());
    }


    public record NavItem(
        string Title,
        string RouteUrl,
        List<string> AlternativeRouteUrls,
        bool IsActive,
        bool IsCurrent = false)
    {
        public bool IsCurrent { get; set; } = IsCurrent;
    }
}
