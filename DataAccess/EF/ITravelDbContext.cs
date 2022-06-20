using System;
using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.DataAccess.EF
{
	public interface ITravelDbContext
	{
        DbSet<User> Users { set; get; }

        DbSet<Booking> Bookings { set; get; }

        DbSet<City> Cities { set; get; }

        DbSet<Place> Places { set; get; }

        DbSet<PlaceType> PlaceTypes { set; get; }

        DbSet<PlaceImage> PlaceImages { set; get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

