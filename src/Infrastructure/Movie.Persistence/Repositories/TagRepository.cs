using Movie.Application.Interfaces.Repositories;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(MovieContext context) : base(context)
        {
        }
    }
}
