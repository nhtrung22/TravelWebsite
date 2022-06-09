using TravelWebsite.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace TravelWebsite.DataAccess.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(500);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        }
    }
}
