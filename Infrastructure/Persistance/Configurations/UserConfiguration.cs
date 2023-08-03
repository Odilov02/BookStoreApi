using Application.Comman.Extentions;

namespace Infrastructure.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.UserName).IsUnique();

        builder.Property(x => x.Password).IsRequired();

        builder.HasData(new User()
        {
            FullName = "Diyorbek",
            UserName = "DiyorbekOdilov",
            PhoneNumber = "+998942922288",
            Password = "diyorbek020819".stringHash(),
        });
    }
}
