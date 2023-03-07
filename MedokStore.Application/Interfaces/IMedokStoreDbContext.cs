using MedokStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MedokStore.Application.Interfaces
{
    public interface IMedokStoreDbContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Gelery> Gelery { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
