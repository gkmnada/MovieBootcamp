using MediatR;
using Movie.Application.Features.Category.Results;

namespace Movie.Application.Features.Category.Queries
{
    public sealed class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public int CategoryID { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            CategoryID = id;
        }
    }
}
