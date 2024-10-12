using Application.Generic;
using MediatR;


namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<GetResponse<GetAllPostsDTO>>
    {
        public bool IncludeCategory { get; set; } = false;
    }
}
