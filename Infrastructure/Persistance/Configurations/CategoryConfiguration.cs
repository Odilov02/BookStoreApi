namespace Infrastructure.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Id).IsRequired();
        builder.HasIndex(x => x.Id).IsUnique();
    }
}
