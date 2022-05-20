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
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(x => x.CityID);
            builder.Property(x => x.CityID).UseIdentityColumn();


            builder.Property(x => x.CityName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
        }
    }
}
