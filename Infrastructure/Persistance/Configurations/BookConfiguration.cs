namespace Infrastructure.Persistance.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

        builder.Property(x => x.ImageUrl).IsRequired();

        builder.Property(x => x.Language).IsRequired().HasMaxLength(50);

        builder.Property(x => x.AuthorId).IsRequired();

        builder.Property(x => x.CategoryId).IsRequired();

        builder.Property(x => x.Count).IsRequired().Metadata.SetIdentityMinValue(0);

        builder.Property(x => x.Price).IsRequired().Metadata.SetIdentityMinValue(0);

        builder.Property(x => x.PageCount).IsRequired().Metadata.SetIdentityMinValue(0);
    }
}
