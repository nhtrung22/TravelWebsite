using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using AutoMapper;
using DataAccess.DTO;

namespace DataAccess.Configurations
{
    public class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Place");

            builder.HasKey(x => x.PlaceID);
            builder.Property(x => x.PlaceID).UseIdentityColumn();


            builder.Property(x => x.PlaceName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);

            builder.Property(x => x.ShortDicription).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Latitude).IsRequired();

            builder.Property(x => x.Longtitude).IsRequired();

            builder.Property(x => x.Thumb).IsRequired();

            builder.Property(x => x.Image).IsRequired();


        }
    }    
}
