using MoserBlog.Application.Contracts.Persistence;
using Moq;
using MoserBlog.Domain.Blog;

namespace MoserBlog.Application.UnitTests.Mocks;

public class BlogEntryRepositoryMock
{
    public static Mock<IBlogEntryRepository> GetRepository()
    {
        var blogEntries = new List<BlogEntry>
        {
            new BlogEntry
            {
                Id = 1,
                Title = "First Blog Entry",
                ShortDescription = "This is the first Blog Entry",
                UrlName = "first-blog-entry",
                IsActive = true,
                PublishDate = DateTime.Now.AddHours(8),
                CreateDate = DateTime.Now
            },
            new BlogEntry
            {
                Id = 2,
                Title = "Second Blog Entry",
                ShortDescription = "This is the second Blog Entry",
                UrlName = "second-blog-entry",
                IsActive = true,
                PublishDate = DateTime.Now.AddHours(12),
                CreateDate = DateTime.Now
            }
        };

        var mockRepository = new Mock<IBlogEntryRepository>();

        mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(blogEntries);
        mockRepository.Setup(repo => repo.FindActiveByUrlNameAsync("second-blog-entry")).ReturnsAsync(blogEntries.FirstOrDefault(x => x.UrlName == "second-blog-entry"));


        return mockRepository;
    }
}
