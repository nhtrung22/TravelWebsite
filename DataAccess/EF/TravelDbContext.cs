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
               .HasOne<PlaceDetail>(s => s.PlaceDetail)
                .WithOne(ad => ad.Place)
                .HasForeignKey<PlaceDetail>(ad => ad.PlaceDetailPlace);


            modelBuilder.Entity<Place>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();


            modelBuilder.Entity<PlaceDetail>()
           .Property(f => f.DetailID)
           .ValueGeneratedOnAdd();

            // Place - Booking
            modelBuilder.Entity<Place>()
            .HasMany(c => c.Bookings)
            .WithOne(e => e.Place);

            modelBuilder.Entity<Booking>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // City - Place
            modelBuilder.Entity<City>()
            .HasMany(c => c.Places)
            .WithOne(e => e.City);

            modelBuilder.Entity<City>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // PlaceType - Place
                modelBuilder.Entity<PlaceType>()
            .HasMany(c => c.Places)
            .WithOne(e => e.PlaceType);

            modelBuilder.Entity<PlaceType>()
             .Property(f => f.Id)
             .ValueGeneratedOnAdd();

            // User
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
            // modelBuilder.Seed();
        }

        public DbSet<User> User { set; get; }

        public DbSet<Booking> Booking { set; get; }

        public DbSet<City> City { set; get; }

        public DbSet<Place> Place { set; get; }

        public DbSet<PlaceDetail> PlaceDetail { set; get; }

        public DbSet<PlaceType> PlaceType { set; get; }

    }
}