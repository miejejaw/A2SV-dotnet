using Blog.Domain.Entities.Common;

namespace Blog.Domain.Entities;
public class Post : BaseEntity
{
    public string Title {get; set;} = string.Empty;
    public string Content { get; set; } = string.Empty;
}