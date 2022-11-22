using Destrix.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destrix.Infra.Data.Mappings
{
    public class UserCategoryMap : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.ToTable("user_categories");

            builder.HasKey(uc => uc.Id);

            builder.Property(uc => uc.Id).HasColumnName("user_category_id");
            builder.Property(uc => uc.CreatedAt).HasColumnName("created_at");
            builder.Property(uc => uc.ChangedAt).HasColumnName("changed_at");
            builder.Property(uc => uc.Active).HasColumnName("active");

            builder.Property(uc => uc.UserId).HasColumnName("user_id");
            builder.Property(uc => uc.Name).HasColumnName("name");
            builder.Property(uc => uc.Description).HasColumnName("description");
        }
    }
}
