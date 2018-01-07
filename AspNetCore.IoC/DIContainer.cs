using AspNetCore.Data.Repositories;
using AspNetCore.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.IoC
{
    public static class DIContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryCategoria, RepositoryCategoria>();
            services.AddTransient<IRepositoryProduto, RepositoryProduto>();
        }
    }
}
