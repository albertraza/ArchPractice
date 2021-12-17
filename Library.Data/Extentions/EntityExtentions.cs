using Library.Domain.BaseEntity;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Extentions
{
    internal static class EntityExtentions
    {
        internal static void ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : Entity
        {
            builder.Property(entity => entity.StateId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(entity => entity.CreatedDate)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(entity => entity.UpdatedDate)
                .HasColumnType("datetime");

            builder.Property(entity => entity.DeletedDate)
                .HasColumnType("datetime");
        }
    }
}
