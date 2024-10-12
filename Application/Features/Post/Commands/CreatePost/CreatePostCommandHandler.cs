

using Application.Contract;
using Application.Generic;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, GetResponse<Domain.Post>>
    {
        private readonly IPostAsyncRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatePostCommandHandler(IPostAsyncRepository postRepository,
            IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<GetResponse<Domain.Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                CreatePostValidator validation = new CreatePostValidator();
                var validationResult = await validation.ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Any())
                {
                    var g = validationResult.Errors.Select(m => m.ErrorMessage).ToList();
                    var d = string.Join(',', validationResult.Errors.Select(m => m.ErrorMessage).ToList());
                    return new GetResponse<Domain.Post>
                    {
                        StatusCode = 400,
                        Message = d ,
                        ObjectData = null
                    };
                }
                var post = _mapper.Map<Domain.Post>(request);
                Domain.Post AddedPost = await _postRepository.AddAsync(post);
                return new GetResponse<Domain.Post>
                {
                    StatusCode = 200,
                    Message = "Added SuccessFully",
                    ObjectData = new List<Domain.Post>() { AddedPost }
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
