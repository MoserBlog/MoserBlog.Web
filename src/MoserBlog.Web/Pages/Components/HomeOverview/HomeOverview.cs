using Microsoft.AspNetCore.Mvc;

namespace MoserBlog.Web.Pages.Components.HomeOverview;

[ViewComponent]
public class HomeOverview : ViewComponent
{
    public IViewComponentResult Invoke() => View(nameof(HomeOverview));
}
