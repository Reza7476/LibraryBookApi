

using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.EntityConfig.Authers;

public class AutherConfig : IEntityTypeConfiguration<Auther>
{
    public void Configure(EntityTypeBuilder<Auther> builder)
    {
       builder.Property(_=>_.Name)
            .HasMaxLength(75)
            
            .IsRequired();

        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
}
