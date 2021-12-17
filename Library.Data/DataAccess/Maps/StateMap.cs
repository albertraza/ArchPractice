using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.DataAccess.Maps
{
    internal class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(state => state.Id)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(state => state.Description)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                    new State
                    {
                        Id = 1,
                        Description = "Active"
                    },
                    new State
                    {
                        Id = 2,
                        Description = "Inactive"
                    }
            );

            builder.ToTable("State");
        }
    }
}
