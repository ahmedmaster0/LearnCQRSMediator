

using Application.Generic;
using MediatR;

namespace Application.Features.Post.Queries.GetPostById
{
    public class GetPostByIdQuery :IRequest<GetResponse<GetPostByIdDTO>>
    {
        public Guid Id { get; set; }
        public bool IncludeCategory { get; set; } = false;
    }
}
