using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelWebsite.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfKids = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PlaceTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_PlaceType_PlaceTypeId",
                        column: x => x.PlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceImage_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "abcxyz", null, "", "Hà Nội" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "xyzabc", null, "", "TP HCM" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "xyzabc", null, "", "Đà Nẵng" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "xyzabc", null, "", "Quảng Ninh" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "xyzabc", null, "", "Quảng Ngãi" }
                });

            migrationBuilder.InsertData(
                table: "PlaceType",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "abcxyz", null, "", "abcxyz" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "LastModified", "LastModifiedBy", "PasswordHash", "PhoneNumber", "UserName", "UserType" },
                values: new object[,]
                {
<<<<<<<< HEAD:DataAccess/Migrations/20220620135830_init.cs
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "admin@gmail.com", null, "", "$2a$11$2WAAT3wUU1SzhzkMqMU6EeDhtAmn320a5VKmE4NX4xVyLc8NSqMNC", "0123456789", "admin", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "owner@gmail.com", null, "", "$2a$11$wswYq2ATZDqU5N9IZKt61O82G6I3NpaHJ9q0VFiJheApmy.OyIpIq", "0123456789", "owner", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "client@gmail.com", null, "", "$2a$11$oG8DYN0QlQnzNykWiKyO1OTHZsJqIUlE/y.uEpxe5oJD2kQqHVte6", "0123456789", "client", 0 }
========
                    { new Guid("00000000-0000-0000-0000-000000000001"), "tphcm", "abc12314121@gmail.com", "$2a$11$SCyhlFSMcaypy6U7csFKu.S5Mp7R4x3MSnSH/xuwZlh/XiwhZlzqa", "0123456789", "user1", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "tphcm", "463412@gmail.com", "$2a$11$Ss.wEWVcF9xyBJi7B.xz5uMgImxdxOfjCvDntfHjbI7DfsQ8YqqRO", "0123456789", "user2", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "hanoi", "241241@gmail.com", "$2a$11$XEZzey4TscbS7ACxqZGxTuY3J9/UwoOHohywIUN2wj8OmxqTibnOG", "0123456789", "user3", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "da nang", "abc1236187854@gmail.com", "$2a$11$78FUFTKezA9ehv4GOmCrUuDxAgakelfwHnl8voviDGZDAbrNK8DdG", "0123456789", "user4", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "da nang", "abc123618654@gmail.com", "$2a$11$OQ/MFpFp2KnmVBq1jTlhDen63eQgJMoENKwH0cOWjvz5jv8CymH1q", "0123456789", "user5", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "da nang", "abc123656714@gmail.com", "$2a$11$0OsVFPVcmpkmM2SH0otuA./oP98lccF0xNKnIqgTGKjCbW9QpLsAC", "0123456789", "user6", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "da nang", "abc123688814@gmail.com", "$2a$11$neQ8XWKq8toH1I78k80Ys.UDWq0UWQX4JqLvgsFLfyKT3b8QQKfrK", "0123456789", "user7", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "da nang", "abc125673614@gmail.com", "$2a$11$/IbjXFNwRtAsvWCYwTWNLukrPgvHz7uPiU8F8Q25UaZOaZIre4x2S", "0123456789", "user8", 1 }
>>>>>>>> 9d60b2836a82a7a1b07223c3ee24cf2b620562f7:DataAccess/Migrations/20220615142647_init.cs
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Created", "CreatedBy", "Discription", "LastModified", "LastModifiedBy", "Name", "NumberOfAdults", "NumberOfKids", "PlaceTypeId", "Price", "UserId" },
                values: new object[] { 1, "bac tu liem", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "abcxyz", null, "", "studio", 0, 0, 1, 0m, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Created", "CreatedBy", "Discription", "LastModified", "LastModifiedBy", "Name", "NumberOfAdults", "NumberOfKids", "PlaceTypeId", "Price", "UserId" },
                values: new object[] { 2, "hoan kiem", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "abcxyz", null, "", "penhouse", 0, 0, 1, 0m, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Created", "CreatedBy", "Discription", "LastModified", "LastModifiedBy", "Name", "NumberOfAdults", "NumberOfKids", "PlaceTypeId", "Price", "UserId" },
                values: new object[] { 3, "quan 1", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "abcxyz", null, "", "palace", 0, 0, 1, 0m, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                table: "Booking",
<<<<<<<< HEAD:DataAccess/Migrations/20220620135830_init.cs
                columns: new[] { "Id", "Created", "CreatedBy", "Deposit", "FromTime", "LastModified", "LastModifiedBy", "PaymentStatus", "PlaceId", "Status", "ToTime", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0m, new DateTime(2022, 6, 10, 20, 58, 29, 872, DateTimeKind.Local).AddTicks(6797), null, "", 2, 1, 0, new DateTime(2022, 6, 30, 20, 58, 29, 872, DateTimeKind.Local).AddTicks(6811), new Guid("00000000-0000-0000-0000-000000000003") });
========
                columns: new[] { "Id", "BookingDate", "BookingFromTime", "BookingToTime", "CurrentUserId", "Deposit", "FullName", "NumberOfAdult", "NumberOfKid", "PaymentStatus", "PhoneNumber", "PlaceId", "Price", "Status" },
                values: new object[] { 1, new DateTime(2022, 5, 31, 21, 26, 47, 375, DateTimeKind.Local).AddTicks(8798), new DateTime(2022, 6, 5, 21, 26, 47, 375, DateTimeKind.Local).AddTicks(8791), new DateTime(2022, 6, 25, 21, 26, 47, 375, DateTimeKind.Local).AddTicks(8797), new Guid("00000000-0000-0000-0000-000000000001"), 0m, "Nguyen A", 1, 3, 2, "0123456789", 1, 50000m, 0 });

            migrationBuilder.InsertData(
                table: "PlaceDetail",
                columns: new[] { "Id", "AC", "CarParking", "PlaceID", "Size", "Square", "TV", "Wifi" },
                values: new object[] { 1, true, true, 1, 3, 50, true, true });

            migrationBuilder.InsertData(
                table: "PlaceImage",
                columns: new[] { "Id", "CurrentPlaceId", "DateCreated", "Location", "Title" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 15, 21, 26, 47, 375, DateTimeKind.Local).AddTicks(8686), "D:\\UserData\\Documents\\source\\repos\\TravelWebsite\\DataAccess\\Image\\1.jpg", "anh1" });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CurrentUserId",
                table: "Booking",
                column: "CurrentUserId");
>>>>>>>> 9d60b2836a82a7a1b07223c3ee24cf2b620562f7:DataAccess/Migrations/20220615142647_init.cs

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlaceId",
                table: "Booking",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_CityId",
                table: "Place",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_PlaceTypeId",
                table: "Place",
                column: "PlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_UserId",
                table: "Place",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImage_PlaceId",
                table: "PlaceImage",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "PlaceImage");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
