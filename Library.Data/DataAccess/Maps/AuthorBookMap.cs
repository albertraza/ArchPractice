using Library.Data.Extentions;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.DataAccess.Maps
{
    internal class AuthorBookMap : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(authorBook => new { authorBook.AuthorId, authorBook.BookId });

            builder.Property(authorBook => authorBook.AuthorId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(authorBook => authorBook.BookId)
                .HasColumnType("int")
                .IsRequired();

            builder.ConfigureBaseEntity();

            builder.HasOne(authorBook => authorBook.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(authorBook => authorBook.AuthorId)
                .IsRequired();

            builder.HasOne(authorBook => authorBook.Book)
                .WithMany(book => book.Authors)
                .HasForeignKey(authorBook => authorBook.BookId)
                .IsRequired();
        }
    }
}
