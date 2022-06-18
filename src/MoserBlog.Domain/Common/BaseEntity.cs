namespace MoserBlog.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
