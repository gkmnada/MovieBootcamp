using Movie.Application.Interfaces.Repositories;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext _context;

        public UnitOfWork(MovieContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
