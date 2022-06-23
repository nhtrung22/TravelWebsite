using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelWebsite.DataAccess.Entities;


namespace TravelWebsite.DataAccess.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            //builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        }
    }
}
