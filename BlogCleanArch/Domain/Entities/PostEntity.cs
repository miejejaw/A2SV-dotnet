
using Domain.Common;

namespace Domain.Entities;

public class PostEntity : BaseDomainEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<Comment> Comments { get; set; } = new List<Comment>();
}