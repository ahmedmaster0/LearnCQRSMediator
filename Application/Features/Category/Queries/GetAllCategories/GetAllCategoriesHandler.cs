

using Application.Contract;
using Application.Generic;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, GetResponse<GetAllCategoryDTO>>
    {
        private readonly ICategoryAsyncRepository _categoryAsyncRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriesHandler(ICategoryAsyncRepository categoryAsyncRepository,
            IMapper mapper)
        {
            _categoryAsyncRepository = categoryAsyncRepository;
            _mapper = mapper;
        }
        public async Task<GetResponse<GetAllCategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var lst_cats = await _categoryAsyncRepository.GetAllCategoriesAsync(true);
                IEnumerable<GetAllCategoryDTO> allCategories = _mapper.Map<IEnumerable<GetAllCategoryDTO>>(lst_cats);

                return new GetResponse<GetAllCategoryDTO>
                {
                    Message=string.Empty,
                    StatusCode = 200,
                    ObjectData = allCategories
                };
            }
            catch (Exception ex) 
            {
                return new GetResponse<GetAllCategoryDTO>
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    ObjectData = Enumerable.Empty<GetAllCategoryDTO>()
                };
            } 
        }
    }
}
