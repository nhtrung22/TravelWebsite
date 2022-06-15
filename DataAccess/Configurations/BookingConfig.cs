using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.DataAccess.Configurations
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.FromTime).IsRequired();

            builder.Property(x => x.ToTime).IsRequired();

            builder.Property(x => x.NumberOfAdult).IsRequired();

            builder.Property(x => x.NumberOfKid).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.Date).IsRequired();

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.PaymentStatus).IsRequired();

            builder.Property(x => x.Deposit).IsRequired();
        }
    }
}
