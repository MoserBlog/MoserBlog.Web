using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoserBlog.Web.Pages;

public class BlogDetailModel : PageModel
{
    [ViewData]
    public string PageTitle { get; set; }

    private readonly ILogger<BlogDetailModel> _logger;

    public BlogDetailModel(ILogger<BlogDetailModel> logger)
    {
        PageTitle = "Detail";

        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
}
