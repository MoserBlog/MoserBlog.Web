using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoserBlog.Web.Pages;

public class IndexModel : PageModel
{
    [ViewData]
    public string PageTitle { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        PageTitle = "Home";

        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
}
