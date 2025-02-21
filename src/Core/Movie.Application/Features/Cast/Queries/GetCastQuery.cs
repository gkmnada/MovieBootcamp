using MediatR;
using Movie.Application.Features.Cast.Results;

namespace Movie.Application.Features.Cast.Queries
{
    public sealed class GetCastQuery : IRequest<ICollection<GetCastQueryResult>>
    {
    }
}
