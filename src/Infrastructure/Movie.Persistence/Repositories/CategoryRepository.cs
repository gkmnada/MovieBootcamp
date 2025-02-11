using Movie.Application.Interfaces.Repositories;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieContext context) : base(context)
        {
        }
    }
}
