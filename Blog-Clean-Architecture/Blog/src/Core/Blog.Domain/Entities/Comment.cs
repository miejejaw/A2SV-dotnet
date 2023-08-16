
using Blog.Domain.Entities.Common;

namespace Blog.Domain.Entities;
public class Comment : BaseEntity
{
    public int PostId { get; set; }
    public string? Text { get; set; }    

}