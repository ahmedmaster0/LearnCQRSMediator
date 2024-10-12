
using Application.Contract;
using Application.Generic;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetResponse<GetAllPostsDTO>>
    {
        private readonly IPostAsyncRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(IPostAsyncRepository postAsyncRepository,
            IMapper mapper)
        {
            _postRepository = postAsyncRepository;
            _mapper = mapper;
        }
        public async Task<GetResponse<GetAllPostsDTO>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var lst_posts = request.IncludeCategory == true ? await _postRepository.GetAllPostsAsync(true) : await _postRepository.GetAllPostsAsync(false);
                return new GetResponse<GetAllPostsDTO>
                {
                    StatusCode = 200,
                    Message = string.Empty,
                    ObjectData = _mapper.Map<List<GetAllPostsDTO>>(lst_posts)
                };
            }
            catch (Exception ex) 
            {
                return new GetResponse<GetAllPostsDTO>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    ObjectData = null 
                };
            } 
          
        }
    }
}
