

using Application.Contract;
using Application.Generic;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery,GetResponse<GetPostByIdDTO>>
    {
        private readonly IPostAsyncRepository _postAsyncRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IPostAsyncRepository postAsyncRepository,
            IMapper mapper)
        {
            _postAsyncRepository = postAsyncRepository;
            _mapper = mapper;
        }


        public async Task<GetResponse<GetPostByIdDTO>> Handle(GetPostByIdQuery request,CancellationToken cancellationToken)
        {
            try
            {
                var Post = request.IncludeCategory == true ? await _postAsyncRepository.GetPostByIdAsync(request.Id, true) : await _postAsyncRepository.GetPostByIdAsync(request.Id, false);

                return new GetResponse<GetPostByIdDTO>
                {
                    StatusCode = 200,
                    Message = string.Empty,
                    ObjectData = new List<GetPostByIdDTO> { _mapper.Map<GetPostByIdDTO>(Post) }
                };
            }
            catch (Exception ex)
            {
                return new GetResponse<GetPostByIdDTO>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    ObjectData = null
                };
            }
          
        }

    }
}
