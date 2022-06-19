using MoserBlog.Domain.Common;

namespace MoserBlog.Domain.Blog;

public class ContentSection : BaseEntity
{
    public int Position { get; set; }
    public string Content { get; set; }
}
