﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelWebsite.DataAccess.EF;

#nullable disable

namespace TravelWebsite.DataAccess.Migrations
{
    [DbContext(typeof(TravelDbContext))]
    partial class TravelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid?>("CurrentUserId")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("CurrentUserId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Booking", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingDate = new DateTime(2022, 5, 25, 17, 35, 46, 280, DateTimeKind.Local).AddTicks(5444),
                            BookingFromTime = new DateTime(2022, 5, 30, 17, 35, 46, 280, DateTimeKind.Local).AddTicks(5436),
                            BookingToTime = new DateTime(2022, 6, 19, 17, 35, 46, 280, DateTimeKind.Local).AddTicks(5443),
                            CurrentUserId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Deposit = 0m,
                            FullName = "Nguyen A",
                            NumberOfAdult = 1,
                            NumberOfKid = 3,
                            PaymentStatus = 2,
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
                        },
                        new
                        {
                            Id = 2,
                            CityName = "tp hcm",
                            Description = "xyzabc"
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PlaceTypeID");

                    b.HasIndex("UserId");

                    b.ToTable("Place", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "bac tu liem",
                            CityId = 1,
                            Latitude = 3841231423m,
                            Longtitude = 6434523m,
                            Name = "studio",
                            PlaceTypeID = 1,
                            ShortDicription = "abcxyz",
                            UserId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = 2,
                            Address = "hoan kiem",
                            CityId = 1,
                            Latitude = 3841231423m,
                            Longtitude = 6434523m,
                            Name = "penhouse",
                            PlaceTypeID = 1,
                            ShortDicription = "abcxyz",
                            UserId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = 3,
                            Address = "quan 1",
                            CityId = 2,
                            Latitude = 3841231423m,
                            Longtitude = 6434523m,
                            Name = "palace",
                            PlaceTypeID = 1,
                            ShortDicription = "abcxyz",
                            UserId = new Guid("00000000-0000-0000-0000-000000000003")
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

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurrentPlaceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPlaceId");

                    b.ToTable("PlaceImage", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrentPlaceId = 1,
                            DateCreated = new DateTime(2022, 6, 9, 17, 35, 46, 280, DateTimeKind.Local).AddTicks(5405),
                            Location = "D:\\UserData\\Documents\\source\\repos\\TravelWebsite\\DataAccess\\Image\\1.jpg",
                            Title = "anh1"
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

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

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
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Address = "tphcm",
                            Email = "abc12311@gmail.com",
                            PasswordHash = "$2a$11$bzIMLKjJ9izKij/8fxJSnuQS5SCu7RPBIDigI0VYKq4n.YItSCJeW",
                            PhoneNumber = "0123456789",
                            UserName = "user1",
                            UserType = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Address = "bac ninh",
                            Email = "abc123664@gmail.com",
                            PasswordHash = "$2a$11$ZS0csoKg3BRu6Mnj9foZdejS8qL/n8VXydb2JUOrx27WifmyhWPWu",
                            PhoneNumber = "0123456789",
                            UserName = "user2",
                            UserType = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Address = "hanoi",
                            Email = "abc123623@gmail.com",
                            PasswordHash = "$2a$11$wSiboozhHlUz7cVHDSUPieuFMwbQqBZn8PDctC04TX.UYLjKJPdpa",
                            PhoneNumber = "0123456789",
                            UserName = "user3",
                            UserType = 0
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            Address = "da nang",
                            Email = "abc123614@gmail.com",
                            PasswordHash = "$2a$11$1yGb7zZL7SmlmG8AO381xOOOKneuapqH17wvmDxMuEQ7DO073SrF6",
                            PhoneNumber = "0123456789",
                            UserName = "user4",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Booking", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("CurrentUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithMany("Bookings")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
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

                    b.HasOne("TravelWebsite.DataAccess.Entities.User", "User")
                        .WithMany("Places")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("PlaceType");

                    b.Navigation("User");
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

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceImage", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithMany("Images")
                        .HasForeignKey("CurrentPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.User", b =>
                {
                    b.OwnsMany("TravelWebsite.DataAccess.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

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

                            b1.WithOwner("User")
                                .HasForeignKey("UserId");

                            b1.Navigation("User");
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

                    b.Navigation("Images");

                    b.Navigation("PlaceDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceType", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
