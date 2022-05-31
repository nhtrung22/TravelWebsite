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
    public class PlaceTypeConfig : IEntityTypeConfiguration<PlaceType>
    {
        public void Configure(EntityTypeBuilder<PlaceType> builder)
        {
            builder.ToTable("PlaceType");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
