using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MoserBlog.Web.Pages;

public class ContactModel : PageModel
{
    [ViewData]
    public string PageTitle { get; set; }

    private readonly ILogger<ContactModel> _logger;

    public ContactModel(ILogger<ContactModel> logger)
    {
        PageTitle = "Contact";

        _logger = logger;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
}
