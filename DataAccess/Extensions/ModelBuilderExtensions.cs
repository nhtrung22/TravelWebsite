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
                    UserName = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Admin,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "owner",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "owner@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Owner,
                },
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "client",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "client@gmail.com",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
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
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType()
                {
                    Id = 1,
                    Name = "abcxyz",
                    Description = "abcxyz"
                }
            );
            //Place
            modelBuilder.Entity<Property>().HasData(
                new Property()
                {
                    Id = 1,
                    Name = "studio",
                    Address = "bac tu liem",
                    Discription = "abcxyz",
                    CityId = 1,
                    PlaceTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                },
                new Property()
                {
                    Id = 2,
                    Name = "penhouse",
                    Address = "hoan kiem",
                    Discription = "abcxyz",
                    CityId = 1,
                    PlaceTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                },
                new Property()
                {
                    Id = 3,
                    Name = "palace",
                    Address = "quan 1",
                    Discription = "abcxyz",
                    CityId = 2,
                    PlaceTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002"),
                }
            );

            // Booking
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    Id = 1,
                    FromTime = DateTime.Now.AddDays(-10),
                    ToTime = DateTime.Now.AddDays(10),
                    Status = 0,
                    PaymentStatus = PaymentStatus.Paid,
                    Deposit = 0,
                    PlaceId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000003")
                }
            );
        }
    }
}
