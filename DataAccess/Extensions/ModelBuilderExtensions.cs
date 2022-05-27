
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EF;

namespace DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserID = 1,
                    UserName = "user1",
                    Password = "123456",
                    Email = "abc123@gmail.com",
                    Adress = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = 1,
                    Status = 0
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserID = 2,
                    UserName = "user2",
                    Password = "123456",
                    Email = "abc123@gmail.com",
                    Adress = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = 1,
                    Status = 0
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserID = 3,
                    UserName = "user3",
                    Password = "123456",
                    Email = "abc123@gmail.com",
                    Adress = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = 1,
                    Status = 0
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
            // Place Type
            modelBuilder.Entity<PlaceType>().HasData(
                new PlaceType()
                {
                    Id = 1,
                    PlaceTypeName = "abcxyz",
                    PlaceTypeDescription = "abcxyz"
                }
            );
            //Place
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    Id = 1,
                    PlaceName = "studio",
                    Address = "hoan kiem, ha noi",
                    ShortDicription = "abcxyz",
                    Latitude = 21.0278M,
                    Longtitude = 105.8342M,
                    Thumb = "abcxyz",
                    Image = "abcxyz",
                    CurrentCityId = 1,
                    CurrentPlaceTypeId = 1
                    //BookingID = 1
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
                    PaymentStatus = 0,
                    Deposit = 0,
                    PhoneNumber = "0123456789",
                    FullName = "Nguyen A",
                    CurrentPlaceId = 1

                }
            );




            // Place Detail
            modelBuilder.Entity<PlaceDetail>().HasData(
                new PlaceDetail()
                {
                    DetailID = 1,
                    Wifi = true,
                    TV = true,
                    AC = true,
                    CarParking = true,
                    Size = 3,
                    Square = 50,
                    PlaceDetailPlace = 1
                }
            );

        }
    }
}
