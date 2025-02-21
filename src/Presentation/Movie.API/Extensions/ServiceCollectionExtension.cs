using Movie.Application.Interfaces.Repositories;
using Movie.Persistence.Repositories;

namespace Movie.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICastRepository, CastRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
