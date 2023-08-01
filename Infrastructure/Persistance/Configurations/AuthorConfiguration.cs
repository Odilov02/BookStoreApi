using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

        builder.Property(x => x.ImgUrl).IsRequired();
    }
}
