using Library.Data.Extentions;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.DataAccess.Maps
{
    internal class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(book => book.Id)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(book => book.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(book => book.Description)
                .HasColumnType("varchar")
                .HasMaxLength(125);

            builder.ConfigureBaseEntity();
        }
    }
}
