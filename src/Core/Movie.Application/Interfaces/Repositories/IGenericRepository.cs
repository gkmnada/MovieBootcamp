namespace Movie.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> ListAsync(CancellationToken cancellationToken);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
