
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
                  UserName = "abc123",
                  Password = "123456",
                  Email = "abc123@gmail.com",
                  Adress = "hanoi",
                  PhoneNumber = "7921409135",
                  UserType = 1,
                  Status = 0 
                }   
            );

            // Place
            modelBuilder.Entity<Place>().HasData(
                new Place()
                {
                    PlaceID = 1,
                    PlaceName = "abc123",
                    Address = "hanoi",
                    ShortDicription = "kald;sf voiwejp",
                    Latitude = 21.0278M,
                    Longtitude = 105.8342M,
                    Thumb = "adsfasdva",
                    Image = "ljfasdkjf"
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
                    Square = 50
                }
            );

            // Booking
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                {
                    BookingID = 1,
                    BookingFromTime = DateTime.Now.AddDays(-10),
                    BookingToTime = DateTime.Now.AddDays(10),
                    NumberOfAdult = 1,
                    NumberOfKid = 3,
                    Price = 50,
                    BookingDate = DateTime.Now.AddDays(-15),
                    Status = 0,
                    PaymentStatus = 0,
                    Deposit = 0,
                    PhoneNumber = "8983424",
                    FullName = "Nguyen A"
                }
            );

            // City
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    CityID = 1,
                    CityName = "ha noi",
                    Description = "LDKJfL"
                }
            );

            // Place Type
            modelBuilder.Entity<PlaceType>().HasData(
                new PlaceType()
                {
                    PlaceTypeID = 1,
                    PlaceTypeName = "adqfefqw",
                    PlaceTypeDescription = "kvjaskd"
                }
            ); 
        }
    }
}
