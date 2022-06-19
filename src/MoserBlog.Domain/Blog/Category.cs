using MoserBlog.Domain.Common;

namespace MoserBlog.Domain.Blog;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<BlogEntry> BlogEntries { get; set; }
}
