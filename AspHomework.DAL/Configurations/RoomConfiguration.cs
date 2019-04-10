using AspHomework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspHomework.DAL.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();      

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                //Fluent API doesn't have setting for min length.
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.OpenFrom)
                .IsRequired();

            builder.Property(p => p.OpenTo)
                .IsRequired();

            builder.HasMany(p => p.Reservations)
                .WithOne(p => p.Room);
        }
    }
}
