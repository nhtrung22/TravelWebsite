using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelWebsite.DataAccess.Entities;
//using DataAccess.DTO;

namespace TravelWebsite.DataAccess.Configurations
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,4)");
            builder.Property(x => x.PropertyTypeId).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
        }
    }
}
