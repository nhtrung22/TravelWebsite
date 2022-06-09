using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Configurations;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Extensions;
namespace TravelWebsite.DataAccess.EF
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

            // Place - Image
            modelBuilder.Entity<PlaceImage>()
            .HasOne<Place>(s => s.Place)
            .WithMany(g => g.Images)
            .HasForeignKey(s => s.CurrentPlaceId);

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

            // User - Booking
            modelBuilder.Entity<Booking>()
            .HasOne<User>(s => s.User)
            .WithMany(g => g.Bookings)
            .HasForeignKey(s => s.CurrentUserId).OnDelete(DeleteBehavior.NoAction);

            // User - Place
            modelBuilder.Entity<Place>()
            .HasOne<User>(s => s.User)
            .WithMany(g => g.Places)
            .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

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

            modelBuilder.ApplyConfiguration(new PlaceImageConfig());

            

            // Seeding data
            modelBuilder.Seed();
        }

        public DbSet<User> Users { set; get; }

        public DbSet<Booking> Bookings { set; get; }

        public DbSet<City> Cities { set; get; }

        public DbSet<Place> Places { set; get; }

        public DbSet<PlaceDetail> PlaceDetails { set; get; }

        public DbSet<PlaceType> PlaceTypes { set; get; }

        public DbSet<PlaceImage> Images { set; get; }

    }
}