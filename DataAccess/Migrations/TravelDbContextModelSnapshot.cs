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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("FromTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Deposit = 0m,
                            FromTime = new DateTime(2022, 6, 10, 20, 58, 29, 872, DateTimeKind.Local).AddTicks(6797),
                            LastModifiedBy = "",
                            PaymentStatus = 2,
                            PlaceId = 1,
                            Status = 0,
                            ToTime = new DateTime(2022, 6, 30, 20, 58, 29, 872, DateTimeKind.Local).AddTicks(6811),
                            UserId = new Guid("00000000-0000-0000-0000-000000000003")
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "abcxyz",
                            LastModifiedBy = "",
                            Name = "Hà Nội"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "xyzabc",
                            LastModifiedBy = "",
                            Name = "TP HCM"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "xyzabc",
                            LastModifiedBy = "",
                            Name = "Đà Nẵng"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "xyzabc",
                            LastModifiedBy = "",
                            Name = "Quảng Ninh"
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "xyzabc",
                            LastModifiedBy = "",
                            Name = "Quảng Ngãi"
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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfKids")
                        .HasColumnType("int");

                    b.Property<int>("PlaceTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PlaceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Place", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "bac tu liem",
                            CityId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Discription = "abcxyz",
                            LastModifiedBy = "",
                            Name = "studio",
                            NumberOfAdults = 0,
                            NumberOfKids = 0,
                            PlaceTypeId = 1,
                            Price = 0m,
                            UserId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = 2,
                            Address = "hoan kiem",
                            CityId = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Discription = "abcxyz",
                            LastModifiedBy = "",
                            Name = "penhouse",
                            NumberOfAdults = 0,
                            NumberOfKids = 0,
                            PlaceTypeId = 1,
                            Price = 0m,
                            UserId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = 3,
                            Address = "quan 1",
                            CityId = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Discription = "abcxyz",
                            LastModifiedBy = "",
                            Name = "palace",
                            NumberOfAdults = 0,
                            NumberOfKids = 0,
                            PlaceTypeId = 1,
                            Price = 0m,
                            UserId = new Guid("00000000-0000-0000-0000-000000000002")
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceImage", (string)null);
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Description = "abcxyz",
                            LastModifiedBy = "",
                            Name = "abcxyz"
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Email = "admin@gmail.com",
                            LastModifiedBy = "",
                            PasswordHash = "$2a$11$2WAAT3wUU1SzhzkMqMU6EeDhtAmn320a5VKmE4NX4xVyLc8NSqMNC",
                            PhoneNumber = "0123456789",
                            UserName = "admin",
                            UserType = 2
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Email = "owner@gmail.com",
                            LastModifiedBy = "",
                            PasswordHash = "$2a$11$wswYq2ATZDqU5N9IZKt61O82G6I3NpaHJ9q0VFiJheApmy.OyIpIq",
                            PhoneNumber = "0123456789",
                            UserName = "owner",
                            UserType = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "",
                            Email = "client@gmail.com",
                            LastModifiedBy = "",
                            PasswordHash = "$2a$11$oG8DYN0QlQnzNykWiKyO1OTHZsJqIUlE/y.uEpxe5oJD2kQqHVte6",
                            PhoneNumber = "0123456789",
                            UserName = "client",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.Booking", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithMany("Bookings")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelWebsite.DataAccess.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
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
                        .HasForeignKey("PlaceTypeId")
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

            modelBuilder.Entity("TravelWebsite.DataAccess.Entities.PlaceImage", b =>
                {
                    b.HasOne("TravelWebsite.DataAccess.Entities.Place", "Place")
                        .WithMany("PlaceImages")
                        .HasForeignKey("PlaceId")
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

                    b.Navigation("PlaceImages");
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
