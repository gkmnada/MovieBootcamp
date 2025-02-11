using Movie.Application.Interfaces.Repositories;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class CastRepository : GenericRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieContext context) : base(context)
        {
        }
    }
}
