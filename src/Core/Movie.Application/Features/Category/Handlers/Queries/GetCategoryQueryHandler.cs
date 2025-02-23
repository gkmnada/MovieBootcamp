using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Features.Category.Queries;
using Movie.Application.Features.Category.Results;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Category.Handlers.Queries
{
    public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ICollection<GetCategoryQueryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryQueryHandler> _logger;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.ListAsync(cancellationToken);
                return _mapper.Map<ICollection<GetCategoryQueryResult>>(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories");
                throw new Exception("An error occurred while fetching categories", ex);
            }
        }
    }
}
