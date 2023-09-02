using Application.DTOs.Comment;
using MediatR;

namespace Application.Features.Comment.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int CommentId { get; set; }
        public CommentRequestDto? UpdateComment{ get; set; }
    }
}
