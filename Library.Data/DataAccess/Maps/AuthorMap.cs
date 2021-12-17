using Library.Data.Extentions;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.DataAccess.Maps
{
    internal class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);

            builder.Property(author => author.Id)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(author => author.Firstname)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(author => author.Lastname)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(author => author.DateBorn)
                .HasColumnType("datetime")
                .IsRequired();

            builder.ConfigureBaseEntity();
        }
    }
}
