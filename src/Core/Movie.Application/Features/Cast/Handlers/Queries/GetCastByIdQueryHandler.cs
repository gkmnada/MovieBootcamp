using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Features.Cast.Queries;
using Movie.Application.Features.Cast.Results;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Cast.Handlers.Queries
{
    public sealed class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly ICastRepository _castRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCastByIdQueryHandler> _logger;

        public GetCastByIdQueryHandler(ICastRepository castRepository, IMapper mapper, ILogger<GetCastByIdQueryHandler> logger)
        {
            _castRepository = castRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _castRepository.GetByIdAsync(request.CastID, cancellationToken);
                return _mapper.Map<GetCastByIdQueryResult>(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the cast by ID");
                throw new Exception("An error occurred while fetching the cast by ID", ex);
            }
        }
    }
}
