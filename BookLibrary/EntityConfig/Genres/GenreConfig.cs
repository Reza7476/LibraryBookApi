using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.EntityConfig.Genres;

public class GenreConfig : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(_ => _.Title)
             .HasMaxLength(75)
             .IsRequired();
    }
}
