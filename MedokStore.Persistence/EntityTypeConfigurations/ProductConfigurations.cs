using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedokStore.Persistence.EntityTypeConfigurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(client => client.ProductId);
            builder.Property(client => client.Name).HasMaxLength(50);
            builder.Property(client => client.Description).HasMaxLength(1000);
            builder.Property(client => client.Compound).HasMaxLength(50);
            builder.Property(client => client.Capacity).HasMaxLength(50);
            builder.Property(client => client.CompleteSet).HasMaxLength(50);
            builder.HasOne(p => p.Category).WithMany(w => w.Products);
        }
    }
}
