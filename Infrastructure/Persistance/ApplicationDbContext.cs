using Application.Comman.Extentions;
using Application.Comman.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : IdentityDbContext<User>, IApplicatonDbcontext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Commentary> Commentaries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        builder.Entity<User>().HasData(
            new User()
            {
                FullName = "Diyorbek",
                Email = "diyorbek02odilov@gmail.com",
                PhoneNumber = "+998942922288",
                PasswordHash = "020819".stringHash(),
            }
            );
    }
}
