using Application.DTOs.Comment;
using MediatR;

namespace Application.Features.Comment.Commands.DeleteComment
{
    public class CreateCommentCommand : IRequest<CommentResponseDto>
    {
        public CommentRequestDto? NewComment { get; set; }
    }
}
