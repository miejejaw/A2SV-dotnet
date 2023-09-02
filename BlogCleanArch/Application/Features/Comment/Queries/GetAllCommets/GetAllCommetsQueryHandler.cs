using Application.Contracts;
using Application.DTOs.Comment;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentResponseDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentResponseDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<CommentResponseDto>>(comments);
        }
    }
}
