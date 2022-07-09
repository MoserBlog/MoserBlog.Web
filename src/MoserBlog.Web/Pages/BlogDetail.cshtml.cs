using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web.Pages;

public class BlogDetailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string UrlName { get; set; } = string.Empty;


    [ViewData]
    public string PageTitle { get; set; }

    public BlogDetailViewModel? ViewModel { get; set; } = null;

    private readonly ILogger<BlogDetailModel> _logger;
    private readonly IBlogService _blogService;

    public BlogDetailModel(ILogger<BlogDetailModel> logger, IBlogService blogService)
    {
        PageTitle = "Detail";

        _logger = logger;
        _blogService = blogService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var blogEntry = await _blogService.TryGetBlogEntryByUrlName(UrlName);

        if (blogEntry is null)
        {
            _logger.LogDebug($"BlogEntry could not be found for UrlName { UrlName }");
            Response.Redirect("/");
        }


        ViewModel = new BlogDetailViewModel(
            blogEntry?.Title ?? "",
            blogEntry?.PublishDate,
            null,
            null);

        return Page();
    }


    public record BlogDetailViewModel(
        string Title,
        DateTime? PublishDate,
        AuthorViewModel? Author,
        List<string>? Categories);


    public record AuthorViewModel(
        string Name,
        string Description,
        string ProfilePictureUrl);
}
