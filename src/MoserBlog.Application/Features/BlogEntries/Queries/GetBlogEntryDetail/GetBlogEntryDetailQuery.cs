using MediatR;

namespace MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;

public class GetBlogEntryDetailQuery : IRequest<BlogEntryDetailVm>
{
    public string UrlName { get; set; }
}
