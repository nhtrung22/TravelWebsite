using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Configurations;
using TravelWebsite.DataAccess.Entities;


namespace TravelWebsite.DataAccess.EF
{
    public class TravelDbContext : DbContext, ITravelDbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API

            modelBuilder.Entity<Property>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Property>().HasOne<City>(s => s.City).WithMany(g => g.Properties).HasForeignKey(s => s.CityId);
            modelBuilder.Entity<Property>().HasOne<PropertyType>(s => s.Type).WithMany(g => g.Properties).HasForeignKey(s => s.PropertyTypeId);
            modelBuilder.Entity<Property>().HasOne<User>(s => s.User).WithMany(g => g.Properties).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PropertyType>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Booking>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Booking>().HasOne<Property>(s => s.Property).WithMany(g => g.Bookings).HasForeignKey(s => s.PlaceId);
            modelBuilder.Entity<Booking>().HasOne<User>(s => s.User).WithMany(g => g.Bookings).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasIndex(f => f.Email).IsUnique();



            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new PropertyConfig());

            modelBuilder.ApplyConfiguration(new PropertyTypeConfig());

            modelBuilder.ApplyConfiguration(new CityConfig());

            modelBuilder.ApplyConfiguration(new BookingConfig());

            modelBuilder.ApplyConfiguration(new PropertyImageConfig());

        }

        public DbSet<User> Users { set; get; }

        public DbSet<Booking> Bookings { set; get; }

        public DbSet<City> Cities { set; get; }

        public DbSet<Property> Properties { set; get; }

        public DbSet<PropertyType> PropertyTypes { set; get; }

        public DbSet<PropertyImage> PropertyImages { set; get; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}