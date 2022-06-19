using MoserBlog.Domain.Common;

namespace MoserBlog.Domain.Blog;

public class Author : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string ProfilePictureUrl { get; set; }
}
