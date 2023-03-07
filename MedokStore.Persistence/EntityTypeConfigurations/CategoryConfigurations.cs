using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedokStore.Persistence.EntityTypeConfigurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.CategoryId);
            builder.HasIndex(category => category.CategoryId).IsUnique();
            builder.Property(category => category.Name).HasMaxLength(50);
            builder.Property(category => category.Language).HasMaxLength(5);
        }
    }
}
