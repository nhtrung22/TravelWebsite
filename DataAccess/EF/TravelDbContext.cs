using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Configurations;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Extensions;


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

            modelBuilder.Entity<Place>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Place>().HasOne<City>(s => s.City).WithMany(g => g.Places).HasForeignKey(s => s.CityId);
            modelBuilder.Entity<Place>().HasOne<PlaceType>(s => s.PlaceType).WithMany(g => g.Places).HasForeignKey(s => s.PlaceTypeId);
            modelBuilder.Entity<Place>().HasOne<User>(s => s.User).WithMany(g => g.Places).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlaceType>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Booking>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Booking>().HasOne<Place>(s => s.Place).WithMany(g => g.Bookings).HasForeignKey(s => s.PlaceId);
            modelBuilder.Entity<Booking>().HasOne<User>(s => s.User).WithMany(g => g.Bookings).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<City>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasIndex(f => f.Email).IsUnique();



            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new PlaceConfig());

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

        public DbSet<PlaceType> PlaceTypes { set; get; }

        public DbSet<PlaceImage> PlaceImages { set; get; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}