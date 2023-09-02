using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Post.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand,Unit>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<Unit> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
    {
        var new_post = _mapper.Map<PostEntity>(command.UpdatePost);
        var old_post = await _postRepository.GetByIdAsync(command.PostId,cancellationToken);
        await _postRepository.UpdateAsync(old_post,new_post,cancellationToken);
        return Unit.Value;
    }
}
