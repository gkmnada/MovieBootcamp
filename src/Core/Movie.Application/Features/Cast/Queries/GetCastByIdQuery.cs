using MediatR;
using Movie.Application.Features.Cast.Results;

namespace Movie.Application.Features.Cast.Queries
{
    public sealed class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        public int CastID { get; set; }

        public GetCastByIdQuery(int id)
        {
            CastID = id;
        }
    }
}
