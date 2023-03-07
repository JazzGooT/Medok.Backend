using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedokStore.Persistence.EntityTypeConfigurations
{
    public class GeleryConfigurations : IEntityTypeConfiguration<Gelery>
    {
        public void Configure(EntityTypeBuilder<Gelery> builder)
        {
            builder.HasKey(client => client.GeleryId);

            builder.Property(client => client.Name).HasMaxLength(250);
            builder.Property(client => client.Image).IsRequired();
            builder.HasOne(p => p.Product).WithMany(w => w.Gelery);
        }
    }
}
