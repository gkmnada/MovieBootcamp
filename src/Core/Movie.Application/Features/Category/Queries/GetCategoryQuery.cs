using MediatR;
using Movie.Application.Features.Category.Results;

namespace Movie.Application.Features.Category.Queries
{
    public sealed class GetCategoryQuery : IRequest<ICollection<GetCategoryQueryResult>>
    {
    }
}
