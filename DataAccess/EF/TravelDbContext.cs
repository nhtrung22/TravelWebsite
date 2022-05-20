using DataAccess.Configurations;
using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EF
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
             .Property(f => f.PlaceID)
             .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlaceDetail>()
           .Property(f => f.DetailID)
           .ValueGeneratedOnAdd();

            // Place - Booking
            modelBuilder.Entity<Booking>()
            .Property(f => f.BookingID)
            .ValueGeneratedOnAdd();

            // City - Place
            modelBuilder.Entity<City>()
            .Property(f => f.CityID)
            .ValueGeneratedOnAdd();

            // PlaceType - Place
            modelBuilder.Entity<PlaceType>()
             .Property(f => f.PlaceTypeID)
             .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
          .Property(f => f.UserID)
          .ValueGeneratedOnAdd();


            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new PlaceConfig());

            modelBuilder.ApplyConfiguration(new PlaceDetailConfig());

            modelBuilder.ApplyConfiguration(new PlaceTypeConfig());

            modelBuilder.ApplyConfiguration(new CityConfig());

            modelBuilder.ApplyConfiguration(new BookingConfig());



            // Seeding data
            //modelBuilder.Seed();
        }

        public DbSet<User> User { set; get; }

        public DbSet<Booking> Booking { set; get; }

        public DbSet<City> City { set; get; }

        public DbSet<Place> Place { set; get; }

        public DbSet<PlaceDetail> PlaceDetail { set; get; }

        public DbSet<PlaceType> PlaceType { set; get; }

    }
}