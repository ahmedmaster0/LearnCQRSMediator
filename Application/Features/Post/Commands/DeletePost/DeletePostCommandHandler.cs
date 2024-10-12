

using Application.Contract;
using Application.Generic;
using MediatR;

namespace Application.Features.Post.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, GetResponse<Domain.Post>>
    {
        private readonly IPostAsyncRepository _postRepository;
        public DeletePostCommandHandler(IPostAsyncRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GetResponse<Domain.Post>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(request.Id, true);
                await _postRepository.DeleteByIdAsync(post);

                return new GetResponse<Domain.Post>
                {
                    StatusCode = 200,
                    Message = "Deleted Successfully",
                    ObjectData = null
                };

            }
            catch (Exception ex)
            {
                return new GetResponse<Domain.Post>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    ObjectData = null
                };
            }
        }
    }
}
