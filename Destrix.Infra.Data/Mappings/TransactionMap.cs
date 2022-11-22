using Destrix.Domain.Entities.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destrix.Infra.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("transaction_id");
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.ChangedAt).HasColumnName("changed_at");
            builder.Property(t => t.Active).HasColumnName("active");

            builder.Property(t => t.UserId).HasColumnName("user_id");
            builder.Property(t => t.TransactionReference).HasColumnName("transaction_reference");
            builder.Property(t => t.Amount).HasColumnName("amount");
            builder.Property(t => t.TransactionType).HasColumnName("transaction_type");
            builder.Property(t => t.TransactionDate).HasColumnName("transaction_date");
            builder.Property(t => t.Description).HasColumnName("description");

            builder.HasMany(t => t.Categories)
                .WithOne(c => c.Transaction)
                .HasForeignKey(t => t.TransactionId);
        }
    }
}
