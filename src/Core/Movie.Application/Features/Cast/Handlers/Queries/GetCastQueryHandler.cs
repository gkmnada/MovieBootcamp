using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Features.Cast.Queries;
using Movie.Application.Features.Cast.Results;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Cast.Handlers.Queries
{
    public sealed class GetCastQueryHandler : IRequestHandler<GetCastQuery, ICollection<GetCastQueryResult>>
    {
        private readonly ICastRepository _castRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCastQueryHandler> _logger;

        public GetCastQueryHandler(ICastRepository castRepository, IMapper mapper, ILogger<GetCastQueryHandler> logger)
        {
            _castRepository = castRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _castRepository.ListAsync(cancellationToken);
                return _mapper.Map<ICollection<GetCastQueryResult>>(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching casts");
                throw new Exception("An error occurred while fetching casts", ex);
            }
        }
    }
}
