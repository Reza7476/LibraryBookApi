using BookLibrary.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.EntityConfig.Books;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(_ => _.Count)

              .IsRequired();

        builder.Property(_ => _.Title)
            .HasMaxLength(70)
            .IsRequired();


        builder.Property(_=>_.Category)
            .HasMaxLength(75)
            .IsRequired();


    }
}
