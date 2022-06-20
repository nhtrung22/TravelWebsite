using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Configurations;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Enums;
using TravelWebsite.DataAccess.Extensions;


namespace TravelWebsite.DataAccess.EF
{
    public class TravelDbContextInitialiser
    {
        private readonly TravelDbContext _travelDbContext;
        public TravelDbContextInitialiser(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }

        public async Task InitialiseAsync()
        {
            if (_travelDbContext.Database.IsSqlServer())
            {
                await _travelDbContext.Database.MigrateAsync();
            }
        }

        public async Task SeedAsync()
        {
            if (!_travelDbContext.Users.Any())
            {
                _travelDbContext.Users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "client",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "client@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                });

                await _travelDbContext.SaveChangesAsync();
            }
        }

    }
}