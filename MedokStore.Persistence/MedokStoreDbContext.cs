using MedokStore.Application.Interfaces;
using MedokStore.Domain.Entity;
using MedokStore.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Persistence
{
    public class MedokStoreDbContext : DbContext, IMedokStoreDbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Gelery> Gelery { get; set; }
        public MedokStoreDbContext(DbContextOptions<MedokStoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfigurations());
            builder.ApplyConfiguration(new ProductConfigurations());
            builder.ApplyConfiguration(new GeleryConfigurations());
            base.OnModelCreating(builder);
        }
    }
}
