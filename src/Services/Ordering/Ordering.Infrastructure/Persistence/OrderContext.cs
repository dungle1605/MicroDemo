using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> opts) : base(opts)
    {

    }

    public DbSet<Order> Orders { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "michael";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "michael";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}