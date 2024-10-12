
using Application.Contract;
using Application.Generic;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, GetResponse<Domain.Post>>
    {
        private readonly IPostAsyncRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostCommandHandler(IPostAsyncRepository postRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<GetResponse<Domain.Post>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UpdatePostValidator validations = new UpdatePostValidator();
                var result = await validations.ValidateAsync(request,cancellationToken);
                if (result.Errors.Any()) 
                {
                    return new GetResponse<Domain.Post>
                    {
                        StatusCode = 400,
                        Message = string.Join(',',result.Errors.SelectMany(m => m.ErrorMessage)),
                        ObjectData = null
                    };
                }

                var post = _mapper.Map<Domain.Post>(result);

                await _postRepository.UpdateAsync(post);

                return new GetResponse<Domain.Post>
                {
                    StatusCode = 200,
                    Message = "Updated Successfully",
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
