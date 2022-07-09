namespace MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;

public class BlogEntryOverviewVm
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public DateTime PublishDate { get; set; }
    public string Categories { get; set; }
    public string AuthorName { get; set; }
    public string UrlName { get; set; }
}
