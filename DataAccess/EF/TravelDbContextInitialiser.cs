﻿using Microsoft.EntityFrameworkCore;
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
                    Description = "abcxyz"
                });

                _travelDbContext.Cities.Add(new City
                {
                    Id = 2,
                    Name = "TP HCM",
                    Description = "xyzabc"
                });

                await _travelDbContext.SaveChangesAsync();
            }

            if (!_travelDbContext.PropertyTypes.Any())
            {
                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 1,
                    Name = "Hotel",
                    Description = "abcxyz"
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 2,
                    Name = "Apartment",
                    Description = "abcxyz"
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 3,
                    Name = "Resort",
                    Description = "abcxyz"
                });

                _travelDbContext.PropertyTypes.Add(new PropertyType
                {
                    Id = 4,
                    Name = "Villa",
                    Description = "abcxyz"
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
                    Discription = "abcxyz",
                    CityId = 1,
                    PropertyTypeId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000002")
                });

                _travelDbContext.Properties.Add(new Property
                {
                    Id = 2,
                    Name = "penhouse",
                    Address = "hoan kiem",
                    Discription = "abcxyz",
                    CityId = 1,
                    PropertyTypeId = 1,
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
                    PlaceId = 1,
                    UserId = new Guid("00000000-0000-0000-0000-000000000003")
                });

                await _travelDbContext.SaveChangesAsync();
            }
        }

    }
}