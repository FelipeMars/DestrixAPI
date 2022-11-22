using Destrix.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Destrix.Infra.Data.Contexts
{
    public class DestrixPostgreContext : DbContext
    {
        public DestrixPostgreContext(DbContextOptions<DestrixPostgreContext> options)
            : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DestrixPostgreContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
