using Destrix.Domain.Interfaces.Repositories.Transaction;
using Destrix.Domain.Interfaces.Repositories.User;
using Destrix.Infra.Data.Contexts;
using Destrix.Infra.Data.Repositories.Transaction;
using Destrix.Infra.Data.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Destrix.Infra.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfraDataDependencies(this IServiceCollection services, string connectionDestrixPostgreSQL)
        {
            // PostgreSQL
            services.AddDbContext<DestrixPostgreContext>(options =>
            {
                options.UseNpgsql(connectionDestrixPostgreSQL);
            });

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCategoryRepository, UserCategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
