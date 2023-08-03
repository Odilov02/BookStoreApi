namespace Infrastructure.Persistance.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.Property(x => x.Count).IsRequired();

        builder.Property(x => x.Price).IsRequired();

        builder.Property(x => x.BookId).IsRequired();
        
        builder.Property(x => x.UserId).IsRequired();


    }
}
