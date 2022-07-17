using System.ComponentModel.DataAnnotations.Schema;

namespace MoserBlog.Domain.Common;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
