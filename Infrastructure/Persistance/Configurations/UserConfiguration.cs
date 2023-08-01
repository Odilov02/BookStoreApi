using Application.Comman.Extentions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).IsRequired();
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
        builder.HasData(new User()
        {
            FullName = "Diyorbek",
            Email = "diyorbek02odilov@gmail.com",
            PhoneNumber = "+998942922288",
            PasswordHash = "diyorbek020819".stringHash(),
        });
    }
}
