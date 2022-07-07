using Microsoft.AspNetCore.Mvc;

namespace MoserBlog.Web.Pages.Components.PageHeader;

[ViewComponent]
public class PageHeader : ViewComponent
{
    public IViewComponentResult Invoke() => View(nameof(PageHeader));
}
