using AutoMapper;
using Blog.Domain.Entities;
using Blog.Application.DTOs.Comment;
using Blog.Application.DTOs.Post;

namespace Blog.Application.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile(){
        CreateMap<Post,PostResponseDto>();
        CreateMap<PostRequestDto,Post>();

        CreateMap<Comment,CommentResponseDto>();
        CreateMap<CommentRequestDto,Comment>();
    }
}