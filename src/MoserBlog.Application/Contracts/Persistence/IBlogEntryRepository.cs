using MoserBlog.Domain.Blog;

namespace MoserBlog.Application.Contracts.Persistence;

public interface IBlogEntryRepository : IBaseRepository<BlogEntry>
{
    Task<BlogEntry> FindActiveByUrlNameAsync(string urlName);
    Task<IEnumerable<BlogEntry>> GetLatestForOverviewAsync(int amountOfElements);
}
