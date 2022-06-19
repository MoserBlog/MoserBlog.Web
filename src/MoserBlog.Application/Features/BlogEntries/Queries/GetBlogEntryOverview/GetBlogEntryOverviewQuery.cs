using MediatR;

namespace MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;

public class GetBlogEntryOverviewQuery : IRequest<List<BlogEntryOverviewVm>>
{
    public int AmountOfElements { get; set; }
}
