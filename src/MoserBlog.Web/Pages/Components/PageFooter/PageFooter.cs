using Microsoft.AspNetCore.Mvc;

namespace MoserBlog.Web.Pages.Components.PageFooter;

[ViewComponent]
public class PageFooter : ViewComponent
{
    public IViewComponentResult Invoke() => View(nameof(PageFooter));
}
