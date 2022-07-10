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
            RouteUrl = "/blogs"
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
            .Where(x => x.RouteUrl.Equals(currentRoute.ToLower()))
            .ToList()
            .ForEach(y => y.IsActive = true);

        return View(nameof(PageHeader), _navigationItems);
    }


    public record NavigationItem
    {
        public string Title { get; set; } = string.Empty;
        public string RouteUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
