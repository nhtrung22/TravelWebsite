using TW.DataAccess.Configurations;
using TW.DataAccess.Entities;
using TW.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using TW.DataAccess.Configurations;
using TW.DataAccess.Entities;

namespace TW.DataAccess.EF
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API

            // Relationship
            // Place - PlaceDetail
            modelBuilder.Entity<Place>()
              .HasOne<PlaceDetail>(s => s.PlaceDetail)
               .WithOne(ad => ad.Place)
               .HasForeignKey<PlaceDetail>(ad => ad.PlaceID);


            modelBuilder.Entity<Place>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();


            modelBuilder.Entity<PlaceDetail>()
           .Property(f => f.Id)
           .ValueGeneratedOnAdd();

            // Place - Booking

            modelBuilder.Entity<Booking>()
            .HasOne<Place>(s => s.Place)
            .WithMany(g => g.Bookings)
            .HasForeignKey(s => s.PlaceId);

            modelBuilder.Entity<Booking>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // City - Place
            modelBuilder.Entity<Place>()
            .HasOne<City>(s => s.City)
            .WithMany(g => g.Places)
            .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<City>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // PlaceType - Place
            modelBuilder.Entity<Place>()
            .HasOne<PlaceType>(s => s.PlaceType)
            .WithMany(g => g.Places)
            .HasForeignKey(s => s.PlaceTypeID);

            modelBuilder.Entity<PlaceType>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();

            // User
            modelBuilder.Entity<User>()
          .Property(f => f.Id)
          .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasIndex(f => f.Email).IsUnique();


            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new PlaceConfig());

            modelBuilder.ApplyConfiguration(new PlaceDetailConfig());

            modelBuilder.ApplyConfiguration(new PlaceTypeConfig());

            modelBuilder.ApplyConfiguration(new CityConfig());

            modelBuilder.ApplyConfiguration(new BookingConfig());



            // Seeding data
            modelBuilder.Seed();
        }

        public DbSet<User> User { set; get; }

        public DbSet<Booking> Booking { set; get; }

        public DbSet<City> City { set; get; }

        public DbSet<Place> Place { set; get; }

        public DbSet<PlaceDetail> PlaceDetail { set; get; }

        public DbSet<PlaceType> PlaceType { set; get; }

    }
}