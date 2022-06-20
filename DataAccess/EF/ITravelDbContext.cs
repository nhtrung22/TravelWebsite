using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.DataAccess.EF
{
	public interface ITravelDbContext
	{
        DbSet<User> Users { set; get; }

        DbSet<Booking> Bookings { set; get; }

        DbSet<City> Cities { set; get; }

        DbSet<Property> Properties { set; get; }

        DbSet<PropertyType> PropertyTypes { set; get; }

        DbSet<PropertyImage> PropertyImages { set; get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

