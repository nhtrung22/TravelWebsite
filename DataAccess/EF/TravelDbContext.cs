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
            modelBuilder.Entity<Place>().HasOne(item => item.Booking).WithMany(item => item.Places).HasForeignKey(e => e.BookingId);
            //2 cach viet nay khac nhau (HasOne(item => item.Booking) va HasOne<Booking>()) -> cach sau tu dong sinh ra shadow property
            //tim hieu them 
            //https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            //modelBuilder.Entity<Place>().HasOne<Booking>().WithMany(item => item.Places).HasForeignKey(e => e.BookingId);

            //modelBuilder.Entity<Place>().Property(f => f.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<PlaceDetail>()
           .Property(f => f.DetailID)
           .ValueGeneratedOnAdd();

            // Place - Booking

            modelBuilder.Entity<Booking>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // City - Place
            modelBuilder.Entity<City>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            // PlaceType - Place
            modelBuilder.Entity<PlaceType>()
             .Property(f => f.Id)
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