using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    UserName = "user1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc12314121@gmail.com",
                    Address = "tphcm",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "user2",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "463412@gmail.com",
                    Address = "tphcm",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "user3",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "241241@gmail.com",
                    Address = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    UserName = "user4",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc1236187854@gmail.com",
                    Address = "da nang",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    UserName = "user5",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123618654@gmail.com",
                    Address = "da nang",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    UserName = "user6",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123656714@gmail.com",
                    Address = "da nang",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000007"),
                    UserName = "user7",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123688814@gmail.com",
                    Address = "da nang",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000008"),
                    UserName = "user8",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc125673614@gmail.com",
                    Address = "da nang",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                }
            );


            // City
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Hà Nội",
                    Description = "abcxyz"
                },
                new City()
                {
                    Id = 2,
                    Name = "TP HCM",
                    Description = "xyzabc"
                },
                new City()
                {
                    Id = 3,
                    Name = "Đà Nẵng",
                    Description = "xyzabc"
                },
                new City()
                {
                    Id = 4,
                    Name = "Quảng Ninh",
                    Description = "xyzabc"
                },
                new City()
                {
                    Id = 5,
                    Name = "Quảng Ngãi",
                    Description = "xyzabc"
                }
            );

            // Place Type
            modelBuilder.Entity<PlaceType>().HasData(
                new PlaceType()
                {
                    Id = 1,
                    Name = "abcxyz",
                    Description = "abcxyz"
                }
            );
            //Place
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 1,
                    Name = "studio",
                    Address = "bac tu liem",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 1,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000001")
                },
                new Place()
                {
                    Id = 2,
                    Name = "penhouse",
                    Address = "hoan kiem",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 1,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                },
                new Place()
                {
                    Id = 3,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000003"),
                },
                new Place()
                {
                    Id = 4,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000004"),
                },
                new Place()
                {
                    Id = 5,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000005"),
                },
                new Place()
                {
                    Id = 6,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000006"),
                },
                new Place()
                {
                    Id = 7,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000007"),
                },
                new Place()
                {
                    Id = 8,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000008"),
                }
            );

            // PlaceImage
            modelBuilder.Entity<TravelWebsite.DataAccess.Entities.PlaceImage>().HasData(
                new TravelWebsite.DataAccess.Entities.PlaceImage()
                {
                    Id = 1,
                    Title = "anh1",
                    Location = "D:\\UserData\\Documents\\source\\repos\\TravelWebsite\\DataAccess\\Image\\1.jpg",
                    CurrentPlaceId = 1,
                    DateCreated = DateTime.Now
                }
            );

            // Booking
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    Id = 1,
                    FromTime = DateTime.Now.AddDays(-10),
                    ToTime = DateTime.Now.AddDays(10),
                    NumberOfAdult = 1,
                    NumberOfKid = 3,
                    Price = 50000,
                    Status = 0,
                    PaymentStatus = PaymentStatus.Paid,
                    Deposit = 0,
                    PlaceId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000001")
                }
            );
            // Place Detail
            modelBuilder.Entity<PlaceDetail>().HasData(
                new PlaceDetail()
                {
                    Id = 1,
                    Wifi = true,
                    TV = true,
                    AC = true,
                    CarParking = true,
                    Size = 3,
                    Square = 50,
                    PlaceID = 1
                }
            );
        }
    }
}
