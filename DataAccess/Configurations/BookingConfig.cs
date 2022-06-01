using TravelWebsite.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
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


            builder.Property(x => x.BookingFromTime).IsRequired();

            builder.Property(x => x.BookingToTime).IsRequired();

            builder.Property(x => x.NumberOfAdult).IsRequired();

            builder.Property(x => x.NumberOfKid).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.BookingDate).IsRequired();

            builder.Property(x => x.Status).IsRequired();

            builder.Property(x => x.PaymentStatus).IsRequired();

            builder.Property(x => x.Deposit).IsRequired();

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
        }
    }
}
