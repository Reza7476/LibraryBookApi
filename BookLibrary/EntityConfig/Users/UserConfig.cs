using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.EntityConfig.Users;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(_ => _.Name)
            .HasMaxLength(75)
            .IsRequired();
    }
}
