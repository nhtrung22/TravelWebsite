using TW.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using TW.DataAccess.Entities;

namespace TW.DataAccess.Configurations
{
    public class PlaceDetailConfig : IEntityTypeConfiguration<PlaceDetail>
    {
        public void Configure(EntityTypeBuilder<PlaceDetail> builder)
        {
            builder.ToTable("PlaceDetail");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Wifi).IsRequired();

            builder.Property(x => x.TV).IsRequired();

            builder.Property(x => x.AC).IsRequired();

            builder.Property(x => x.CarParking).IsRequired();

            builder.Property(x => x.Size).IsRequired();

            builder.Property(x => x.Square).IsRequired();
        }
    }
}
