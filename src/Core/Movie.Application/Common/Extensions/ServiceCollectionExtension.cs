using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Features.Cast.Validators;
using Movie.Application.Features.Category.Validators;
using System.Reflection;

namespace Movie.Application.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<CreateCastValidator>();
            services.AddScoped<UpdateCastValidator>();

            services.AddScoped<CreateCategoryValidator>();
            services.AddScoped<UpdateCategoryValidator>();
        }
    }
}
