using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Enums;


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

                _travelDbContext.Users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "owner",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "owner@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Owner,
                });

                _travelDbContext.Users.Add(new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    UserName = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                });

                await _travelDbContext.SaveChangesAsync();
            }

            if (!_travelDbContext.Cities.Any())
            {
                _travelDbContext.Cities.Add(new City
                {
                    Id = 1,
                    Name = "Hà Nội",
                    Description = "abcxyz",
                    Link = "https://cf.bstatic.com/xdata/images/city/max500/957801.webp?k=a969e39bcd40cdcc21786ba92826063e3cb09bf307bcfeac2aa392b838e9b7a5&o="
                });

                _travelDbContext.Cities.Add(new City
                {
                    Id = 2,
                    Name = "TP HCM",
                    Description = "xyzabc",
                    Link = "https://cf.bstatic.com/xdata/images/city/max500/690334.webp?k=b99df435f06a15a1568ddd5f55d239507c0156985577681ab91274f917af6dbb&o="
                });

                _travelDbContext.Cities.Add(new City
                {
                    Id = 3,
                    Name = "Đà Nẵng",
                    Description = "xyzabc",
                    Link = "https://cf.bstatic.com/xdata/images/city/max500/689422.webp?k=2595c93e7e067b9ba95f90713f80ba6e5fa88a66e6e55600bd27a5128808fdf2&o="
                });

                await _travelDbContext.SaveChangesAsync();
            }

            if (!_travelDbContext.PropertyTypes.Any())
            {
                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 1,
                    Name = "Hotel",
                    Description = "abcxyz",
                    Link = "https://cf.bstatic.com/xdata/images/xphoto/square300/57584488.webp?k=bf724e4e9b9b75480bbe7fc675460a089ba6414fe4693b83ea3fdd8e938832a6&o="
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 2,
                    Name = "Apartment",
                    Description = "abcxyz",
                    Link = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/card-image-apartments_300/9f60235dc09a3ac3f0a93adbc901c61ecd1ce72e.jpg"
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 3,
                    Name = "Resort",
                    Description = "abcxyz",
                    Link = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/bg_resorts/6f87c6143fbd51a0bb5d15ca3b9cf84211ab0884.jpg"
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 4,
                    Name = "Villa",
                    Description = "abcxyz",
                    Link = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/card-image-villas_300/dd0d7f8202676306a661aa4f0cf1ffab31286211.jpg"
                });

                await _travelDbContext.SaveChangesAsync();
            }

            if (!_travelDbContext.Properties.Any())
            {
                _travelDbContext.Properties.Add(new Property
                {
                    Id = 1,
                    Name = "studio",
                    Address = "bac tu liem",
                    Description = "Entire studio • 1 bathroom • 21m² 1 full bed",
                    Price = 112,
                    CityId = 1,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 2,
                    PropertyTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 2,
                    Name = "penhouse",
                    Address = "hoan kiem",
                    Description = "Entire studio • 1 bathroom • 21m² 2 full bed",
                    Price = 100,
                    CityId = 2,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 3,
                    PropertyTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 3,
                    Name = "ABC",
                    Address = "Nam A",
                    Description = "Entire studio • 1 bathroom • 21m² 1 full bed",
                    Price = 112,
                    CityId = 3,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 2,
                    PropertyTypeId = 2,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 4,
                    Name = "EF",
                    Address = "Nam A",
                    Description = "Entire studio • 1 bathroom • 21m² 1 full bed",
                    Price = 150,
                    CityId = 3,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 2,
                    PropertyTypeId = 2,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 5,
                    Name = "EFG",
                    Address = "Nam A",
                    Description = "Entire studio • 1 bathroom • 21m² 1 full bed",
                    Price = 150,
                    CityId = 3,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 2,
                    PropertyTypeId = 3,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 6,
                    Name = "EFGH",
                    Address = "Nam A",
                    Description = "Entire studio • 1 bathroom • 21m² 1 full bed",
                    Price = 150,
                    CityId = 3,
                    NumberOfAdults = 1,
                    NumberOfKids = 0,
                    NumberOfRooms = 2,
                    PropertyTypeId = 4,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                await _travelDbContext.SaveChangesAsync();
            }

            if (!_travelDbContext.Bookings.Any())
            {
                _travelDbContext.Bookings.Add(new Booking
                {
                    Id = 1,
                    FromTime = DateTime.Now.AddDays(-10),
                    ToTime = DateTime.Now.AddDays(10),
                    Status = 0,
                    PaymentStatus = PaymentStatus.Paid,
                    Deposit = 0,
                    PropertyId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000003")
                });

                await _travelDbContext.SaveChangesAsync();
            }
        }

    }
}