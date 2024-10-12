using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Commands.UpdatePost;
using Application.Features.Post.Queries.GetAllPosts;
using Application.Features.Post.Queries.GetPostById;
using AutoMapper;
using Domain;


namespace Application.Profiles
{
    public class CustomAutoMapper : Profile
    {
        public CustomAutoMapper()
        {
            CreateMap<Post,GetAllPostsDTO> ().ReverseMap();
            CreateMap<Post,GetPostByIdDTO> ().ReverseMap();

            CreateMap<Post, CreatePostCommand> ().ReverseMap();
            CreateMap<Post, UpdatePostCommand> ().ReverseMap();

            //--------------------------------------------------------

            CreateMap<Category,GetAllCategoryDTO>().ReverseMap();

        }
    }
}
