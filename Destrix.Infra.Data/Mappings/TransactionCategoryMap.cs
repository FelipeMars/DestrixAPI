using Destrix.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destrix.Infra.Data.Mappings
{
    public class TransactionCategoryMap : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.ToTable("transaction_categories");

            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Id).HasColumnName("transaction_category_id");

            builder.Property(tc => tc.TransactionId).HasColumnName("transaction_id");
            builder.Property(tc => tc.UserCategoryId).HasColumnName("user_category_id");
        }
    }
}
