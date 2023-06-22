using Microsoft.Extensions.DependencyInjection;
using CRUDCleanArchitecture.Application.Common.Interfaces.Repositories;

namespace CRUDCleanArchitecture.Infrastructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemRepository, TodoItemsRepository>();

            services.AddTransient<IPersonasRepository, PersonasRepository>();

            return services;
        }
    }
}
