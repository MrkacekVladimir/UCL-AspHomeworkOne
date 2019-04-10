using AspHomework.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspHomework.DAL.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();            

            builder.Property(p => p.ReservedFrom)
                .IsRequired();

            builder.Property(p => p.ReservedTo)
                .IsRequired();

            builder.Property(p => p.Note)
                //Fluent API doesn't have setting for min length.
                .HasMaxLength(500);                
            
            builder.HasOne(p => p.Room)
                .WithMany(p => p.Reservations);

            builder.HasOne(p => p.User)
                .WithMany(p => p.Reservations);
        }
    }
}
