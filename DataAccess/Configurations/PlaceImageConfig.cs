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
    public class PlaceImageConfig : IEntityTypeConfiguration<PlaceImage>
    {
        public void Configure(EntityTypeBuilder<PlaceImage> builder)
        {
            builder.ToTable("PlaceImage");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Location).HasMaxLength(200).IsRequired(true);
        }
    }
}
