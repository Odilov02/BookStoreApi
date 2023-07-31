using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Comman.Interfaces;

public interface IApplicatonDbcontext
{
    EntityEntry Entry(object entity);
    DbSet<Book> Books { get; }
    DbSet<Commentary> Commentaries { get; }
    DbSet<Category> Categories { get; }
    DbSet<Author> Authors { get; }
    DbSet<Order> Orders { get; }
    public DbSet<Basket> Baskets { get; set; }
    Task<int> SaveChangesAsync(CancellationToken token = default);
}
