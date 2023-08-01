namespace Infrastructure.Persistance.Configurations;

public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
{
    public void Configure(EntityTypeBuilder<Commentary> builder)
    {
        builder.Property(x => x.UserId).IsRequired();

        builder.Property(x => x.BookId).IsRequired();

        builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
    }
}
