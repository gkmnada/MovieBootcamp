using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces.Repositories;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MovieContext _context;

        public GenericRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id) ?? throw new Exception("Entity not found");
        }

        public async Task<ICollection<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
    }
}
