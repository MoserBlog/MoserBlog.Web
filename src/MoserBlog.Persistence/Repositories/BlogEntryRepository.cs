using Microsoft.EntityFrameworkCore;
using MoserBlog.Application.Contracts.Persistence;
using MoserBlog.Domain.Blog;

namespace MoserBlog.Persistence.Repositories;

public class BlogEntryRepository : BaseRepository<BlogEntry>, IBlogEntryRepository
{
    public BlogEntryRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }


    public async Task<BlogEntry> FindActiveByUrlNameAsync(string urlName)
    {
        return await _dbContext.BlogEntries.FirstOrDefaultAsync(x => x.IsActive && x.UrlName.Equals(urlName));
    }
}
