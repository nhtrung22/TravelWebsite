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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).UseIdentityColumn();


            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Password).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);

        }
    }
}
