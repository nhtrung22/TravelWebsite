using TravelWebsite.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWebsite.DataAccess.Entities;
using static Microsoft.EntityFrameworkCore.EF;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            // User
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    UserName = "user1",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc12311@gmail.com",
                    Address = "tphcm",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "user2",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123664@gmail.com",
                    Address = "bac ninh",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                    
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "user3",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123623@gmail.com",
                    Address = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    UserName = "user4",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Email = "abc123614@gmail.com",
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
                    CityName = "ha noi",
                    Description = "abcxyz"
                }
            );
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 2,
                    CityName = "tp hcm",
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
                    Thumb = "1",
                    Image = "1",
                    CityId = 1,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000001")
                }
            ); ;
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 2,
                    Name = "penhouse",
                    Address = "hoan kiem",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    Thumb = "1",
                    Image = "1",
                    CityId = 1,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                }
            );
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 3,
                    Name = "palace",
                    Address = "quan 1",
                    ShortDicription = "abcxyz",
                    Latitude = 3841231423,
                    Longtitude = 6434523,
                    Thumb = "1",
                    Image = "1",
                    CityId = 2,
                    PlaceTypeID = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000003")
                }
            );

            // Booking
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    Id = 1,
                    BookingFromTime = DateTime.Now.AddDays(-10),
                    BookingToTime = DateTime.Now.AddDays(10),
                    NumberOfAdult = 1,
                    NumberOfKid = 3,
                    Price = 50000,
                    BookingDate = DateTime.Now.AddDays(-15),
                    Status = 0,
                    PaymentStatus = PaymentStatus.Paid,
                    Deposit = 0,
                    PhoneNumber = "0123456789",
                    FullName = "Nguyen A",
                    PlaceId = 1,
                    CurrentUserId = new Guid("00000000-0000-0000-0000-000000000001")
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
