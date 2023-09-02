using Application.Contracts;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Application.Exceptions;

namespace Application.Features.Comment.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var old_comment = await _commentRepository.GetByIdAsync(command.CommentId,cancellationToken);
            if(old_comment == null)
                throw new NotFoundException($"Comment with id {command.CommentId} does't exist!",command);

            var new_comment = _mapper.Map<CommentEntity>(command.UpdateComment);
            await _commentRepository.UpdateAsync(old_comment, new_comment,cancellationToken);
            return Unit.Value;
        }
    }
}
