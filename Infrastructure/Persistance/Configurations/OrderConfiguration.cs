namespace Infrastructure.Persistance.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.Count).IsRequired();

        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.BookId).IsRequired();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.IsDeliver).IsRequired();

    }
}

