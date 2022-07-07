using MediatR;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web.Services;

public class BlogService : IBlogService
{
    private readonly ILogger<BlogService> _logger;
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public BlogService(ILogger<BlogService> logger,
        IMediator mediator,
        IConfiguration configuration)
    {
        _logger = logger;
        _mediator = mediator;
        _configuration = configuration;
    }


    public async Task<List<BlogEntryOverviewVm>> GetBlogEntriesForOverviewAsync()
    {
        return await _mediator.Send(new GetBlogEntryOverviewQuery()
        {
            AmountOfElements = Convert.ToInt32(_configuration["AmountOfOverviewItems"])
        });
    }
}
