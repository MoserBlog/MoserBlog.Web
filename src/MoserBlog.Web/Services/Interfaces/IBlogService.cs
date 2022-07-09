using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;

namespace MoserBlog.Web.Services.Interfaces;

public interface IBlogService
{
    Task<List<BlogEntryOverviewVm>> GetBlogEntriesForOverviewAsync();
    Task<BlogEntryDetailVm> TryGetBlogEntryByUrlName(string urLName);
}
