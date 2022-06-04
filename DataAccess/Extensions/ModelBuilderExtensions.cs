﻿using TravelWebsite.DataAccess.Entities;
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
            // User
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    UserName = "user1",
                    Password = "123456",
                    Email = "abc123@gmail.com",
                    Address = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                    Status = 0,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    UserName = "user2",
                    Password = "123456",
                    Email = "abc1234@gmail.com",
                    Address = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                    Status = 0,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    UserName = "user3",
                    Password = "123456",
                    Email = "abc1236@gmail.com",
                    Address = "hanoi",
                    PhoneNumber = "0123456789",
                    UserType = UserType.Client,
                    Status = 0,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
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
                    Address = "hoan kiem, ha noi",
                    ShortDicription = "abcxyz",
                    Latitude = 21.0278M,
                    Longtitude = 105.8342M,
                    Thumb = "1",
                    Image = "1",
                    CityId = 1,
                    PlaceTypeID = 1
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
                    PaymentStatus = PaymentStatus.Paid,
                    Deposit = 0,
                    PhoneNumber = "0123456789",
                    FullName = "Nguyen A",
                    PlaceId = 1

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
