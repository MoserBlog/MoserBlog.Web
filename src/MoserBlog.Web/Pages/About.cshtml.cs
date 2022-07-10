using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoserBlog.Web.Pages;

public class AboutModel : PageModel
{
    [ViewData]
    public string PageTitle { get; set; }

    private readonly ILogger<AboutModel> _logger;

    public AboutModel(ILogger<AboutModel> logger)
    {
        PageTitle = "About";

        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
}
