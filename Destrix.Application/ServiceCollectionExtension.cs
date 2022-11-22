using Destrix.Application.Interfaces.Services;
using Destrix.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Destrix.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IBaseService, BaseService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
