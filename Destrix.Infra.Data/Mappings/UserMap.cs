using Destrix.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destrix.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("user_id");
            builder.Property(u => u.CreatedAt).HasColumnName("created_at");
            builder.Property(u => u.ChangedAt).HasColumnName("changed_at");
            builder.Property(u => u.Active).HasColumnName("active");

            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Email).HasColumnName("email");
            builder.Property(u => u.Password).HasColumnName("password");

        }
    }
}
