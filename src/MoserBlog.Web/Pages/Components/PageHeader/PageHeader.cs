using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MoserBlog.Web.Pages.Components.PageHeader;

[ViewComponent]
public class PageHeader : ViewComponent
{
    private readonly List<NavigationItem> _navigationItems = new()
    {
        new()
        {
            Title = "Home",
            RouteUrl = "/index"
        },
        new()
        {
            Title = "Blogs",
            RouteUrl = "/blogs",
            AlternativeRouteUrls = new() { "/blogdetail" }
        },
        new()
        {
            Title = "About",
            RouteUrl = "/about"
        }
    };

    public IViewComponentResult Invoke()
    {
        var currentRoute = ViewContext.ActionDescriptor.RouteValues.ContainsKey("page")
            ? ViewContext.ActionDescriptor.RouteValues["page"] ?? "/" : "/";

        _navigationItems
            .Where(
                x => x.RouteUrl.ToLower().Equals(currentRoute.ToLower()) || 
                x.AlternativeRouteUrls.Any(y => y.ToLower().Equals(currentRoute.ToLower())))
            .ToList()
            .ForEach(y => y.IsCurrent = true);

        return View(nameof(PageHeader), _navigationItems.Where(x => x.IsActive).ToList().AsReadOnly());
    }


    public record NavigationItem
    {
        public string Title { get; set; } = string.Empty;
        public string RouteUrl { get; set; } = string.Empty;
        public List<string> AlternativeRouteUrls { get; set; } = new();
        public bool IsActive { get; set; } = true;
        public bool IsCurrent { get; set; } = false;
    }
}
