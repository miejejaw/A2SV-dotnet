using Application.Contracts;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {

            var comment = await _commentRepository.GetByIdAsync(command.CommentId,cancellationToken);

            if (comment == null)
            {
                throw new NotFoundException($"Comment with id {command.CommentId} does't exist!",command);
            }
 
            await _commentRepository.DeleteAsync(comment, cancellationToken);
            return Unit.Value;
        }
    }
}
