using MoserBlog.Domain.Common;

namespace MoserBlog.Domain.Blog;

public class BlogEntry : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string UrlName { get; set; }

    public bool IsActive { get; set; }
    public DateTime PublishDate { get; set; }

    public Author Author { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<ContentSection> ContentSections { get; set; }
}
