using Blog.Application.DTOs.Common;

namespace Blog.Application.DTOs.Post;
public class PostResponseDto : BaseDto
{
    public string Title {get; set;} = string.Empty;
    public string Content { get; set; } = string.Empty;
}