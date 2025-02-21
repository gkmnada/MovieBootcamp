using Movie.Application.Interfaces.Repositories;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public sealed class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieContext context) : base(context)
        {
        }
    }
}
