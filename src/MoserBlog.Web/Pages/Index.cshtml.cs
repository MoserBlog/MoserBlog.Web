using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;

namespace MoserBlog.Web.Pages;

public class IndexModel : PageModel
{
    public List<BlogEntryOverviewVm> Items { get; private set; } = new();

    private readonly ILogger<IndexModel> _logger;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public IndexModel(ILogger<IndexModel> logger,
        IMediator mediator,
        IConfiguration configuration)
    {
        _logger = logger;
        _mediator = mediator;
        _configuration = configuration;
    }

    public async Task OnGet()
    {
        Items = await _mediator.Send(new GetBlogEntryOverviewQuery()
        {
            AmountOfElements = Convert.ToInt32(_configuration["AmountOfOverviewItems"])
        });
    }
}
