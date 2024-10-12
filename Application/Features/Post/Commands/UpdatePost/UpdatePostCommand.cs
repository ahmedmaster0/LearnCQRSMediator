
using Application.Generic;
using MediatR;

namespace Application.Features.Post.Commands.UpdatePost
{
    public class UpdatePostCommand :IRequest<GetResponse<Domain.Post>>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }

        public Guid CategoryId { get; set; }
    }
}
