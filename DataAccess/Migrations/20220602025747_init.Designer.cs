﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelWebsite.DataAccess.EF;

#nullable disable

namespace TravelWebsite.DataAccess.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    [Migration("20220602025747_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingFromTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingToTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfAdult")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfKid")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Booking", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingDate = new DateTime(2022, 5, 18, 9, 57, 46, 959, DateTimeKind.Local).AddTicks(1113),
                            BookingFromTime = new DateTime(2022, 5, 23, 9, 57, 46, 959, DateTimeKind.Local).AddTicks(1094),
                            BookingToTime = new DateTime(2022, 6, 12, 9, 57, 46, 959, DateTimeKind.Local).AddTicks(1111),
                            Deposit = 0m,
                            FullName = "Nguyen A",
                            NumberOfAdult = 1,
                            NumberOfKid = 3,
                            PaymentStatus = 0,
                            PhoneNumber = "0123456789",
                            PlaceId = 1,
                            Price = 50000m,
                            Status = 0
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "ha noi",
                            Description = "abcxyz"
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longtitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlaceTypeID")
                        .HasColumnType("int");

                    b.Property<string>("ShortDicription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Thumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PlaceTypeID");

                    b.ToTable("Place", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "hoan kiem, ha noi",
                            CityId = 1,
                            Image = "abcxyz",
                            Latitude = 21.0278m,
                            Longtitude = 105.8342m,
                            Name = "studio",
                            PlaceTypeID = 1,
                            ShortDicription = "abcxyz",
                            Thumb = "abcxyz"
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AC")
                        .HasColumnType("bit");

                    b.Property<bool>("CarParking")
                        .HasColumnType("bit");

                    b.Property<int>("PlaceID")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Square")
                        .HasColumnType("int");

                    b.Property<bool>("TV")
                        .HasColumnType("bit");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PlaceID")
                        .IsUnique();

                    b.ToTable("PlaceDetail", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AC = true,
                            CarParking = true,
                            PlaceID = 1,
                            Size = 3,
                            Square = 50,
                            TV = true,
                            Wifi = true
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PlaceType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "abcxyz",
                            Name = "abcxyz"
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Address = "hanoi",
                            Email = "abc123@gmail.com",
                            Password = "123456",
                            PasswordHash = "0a989ebc4a77b56a6e2bb7b19d995d185ce44090c13e2984b7ecc6d446d4b61ea9991b76a4c2f04b1b4d244841449454",
                            PhoneNumber = "0123456789",
                            Status = 0,
                            UserName = "user1",
                            UserType = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Address = "hanoi",
                            Email = "abc1234@gmail.com",
                            Password = "123456",
                            PasswordHash = "0a989ebc4a77b56a6e2bb7b19d995d185ce44090c13e2984b7ecc6d446d4b61ea9991b76a4c2f04b1b4d244841449454",
                            PhoneNumber = "0123456789",
                            Status = 0,
                            UserName = "user2",
                            UserType = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Address = "hanoi",
                            Email = "abc1236@gmail.com",
                            Password = "123456",
                            PasswordHash = "0a989ebc4a77b56a6e2bb7b19d995d185ce44090c13e2984b7ecc6d446d4b61ea9991b76a4c2f04b1b4d244841449454",
                            PhoneNumber = "0123456789",
                            Status = 0,
                            UserName = "user3",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Booking", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithMany("Bookings")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Place", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.City", "City")
                        .WithMany("Places")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelWebsite.DataAccess.Entities.PlaceType", "PlaceType")
                        .WithMany("Places")
                        .HasForeignKey("PlaceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("PlaceType");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceDetail", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithOne("PlaceDetail")
                        .HasForeignKey("TravelWebsite.DataAccess.Entities.PlaceDetail", "PlaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.User", b =>
                {
                    b.OwnsMany("TravelWebsite.DataAccess.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReasonRevoked")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReplacedByToken")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.City", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Place", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("PlaceDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceType", b =>
                {
                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}