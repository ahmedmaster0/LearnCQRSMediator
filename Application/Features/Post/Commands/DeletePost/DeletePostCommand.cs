

using Application.Generic;
using MediatR;

namespace Application.Features.Post.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<GetResponse<Domain.Post>>
    {
        public Guid Id { get; set; }
    }
}
