using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Features.Category.Queries;
using Movie.Application.Features.Category.Results;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Category.Handlers.Queries
{
    public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryByIdQueryHandler> _logger;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryByIdQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _categoryRepository.GetByIdAsync(request.CategoryID, cancellationToken);
                return _mapper.Map<GetCategoryByIdQueryResult>(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the category by ID");
                throw new Exception("An error occurred while fetching the category by ID", ex);
            }
        }
    }
}
