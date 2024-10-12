

using Application.Generic;
using Domain;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<GetResponse<Domain.Post>>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
    }
}
