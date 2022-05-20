using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DataAccess.Configurations
{
    public class PlaceTypeConfig : IEntityTypeConfiguration<PlaceType>
    {
        public void Configure(EntityTypeBuilder<PlaceType> builder)
        {
            builder.ToTable("PlaceType");

            builder.HasKey(x => x.PlaceTypeID);
            builder.Property(x => x.PlaceTypeID).UseIdentityColumn();


            builder.Property(x => x.PlaceTypeName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.PlaceTypeDescription).IsRequired().HasMaxLength(200);
        }
    }
}
