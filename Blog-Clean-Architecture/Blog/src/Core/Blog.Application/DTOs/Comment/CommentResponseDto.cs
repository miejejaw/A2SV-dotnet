using Blog.Application.DTOs.Common;

namespace Blog.Application.DTOs.Comment;
public class CommentResponseDto : BaseDto
{
    public int PostId { get; set; }
    public string? Text { get; set; } = string.Empty;  

}