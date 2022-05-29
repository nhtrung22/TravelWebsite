using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
<<<<<<<< HEAD:DataAccess/Migrations/20220526152755_init.cs
    public partial class init : Migration
========
    public partial class v1 : Migration
>>>>>>>> TrungNH:DataAccess/Migrations/20220527043344_v1.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    PlaceTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlaceTypeDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDicription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longtitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
<<<<<<<< HEAD:DataAccess/Migrations/20220526152755_init.cs
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PlaceTypeId = table.Column<int>(type: "int", nullable: true)
========
                    CurrentCityId = table.Column<int>(type: "int", nullable: false),
                    CurrentPlaceTypeId = table.Column<int>(type: "int", nullable: false)
>>>>>>>> TrungNH:DataAccess/Migrations/20220527043344_v1.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
<<<<<<<< HEAD:DataAccess/Migrations/20220526152755_init.cs
                        name: "FK_Place_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_City_CityId",
                        column: x => x.CityId,
========
                        name: "FK_Place_City_CurrentCityId",
                        column: x => x.CurrentCityId,
>>>>>>>> TrungNH:DataAccess/Migrations/20220527043344_v1.cs
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_PlaceType_CurrentPlaceTypeId",
                        column: x => x.CurrentPlaceTypeId,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingFromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAdult = table.Column<int>(type: "int", nullable: false),
                    NumberOfKid = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Place_CurrentPlaceId",
                        column: x => x.CurrentPlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceDetail",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wifi = table.Column<bool>(type: "bit", nullable: false),
                    TV = table.Column<bool>(type: "bit", nullable: false),
                    AC = table.Column<bool>(type: "bit", nullable: false),
                    CarParking = table.Column<bool>(type: "bit", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Square = table.Column<int>(type: "int", nullable: false),
                    PlaceDetailPlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceDetail", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_PlaceDetail_Place_PlaceDetailPlace",
                        column: x => x.PlaceDetailPlace,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
<<<<<<<< HEAD:DataAccess/Migrations/20220526152755_init.cs
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingFromTime", "BookingToTime", "Deposit", "FullName", "NumberOfAdult", "NumberOfKid", "PaymentStatus", "PhoneNumber", "Price", "Status" },
                values: new object[] { 1, new DateTime(2022, 5, 11, 15, 27, 54, 907, DateTimeKind.Local).AddTicks(7301), new DateTime(2022, 5, 16, 15, 27, 54, 907, DateTimeKind.Local).AddTicks(7282), new DateTime(2022, 6, 5, 15, 27, 54, 907, DateTimeKind.Local).AddTicks(7298), 0m, "Nguyen A", 1, 3, 0, "8983424", 50m, 0 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "Description" },
                values: new object[] { 1, "ha noi", "LDKJfL" });

            migrationBuilder.InsertData(
                table: "PlaceDetail",
                columns: new[] { "DetailID", "AC", "CarParking", "PlaceId", "Size", "Square", "TV", "Wifi" },
                values: new object[] { 1, true, true, null, 3, 50, true, true });
========
                table: "City",
                columns: new[] { "Id", "CityName", "Description" },
                values: new object[] { 1, "ha noi", "abcxyz" });
>>>>>>>> TrungNH:DataAccess/Migrations/20220527043344_v1.cs

            migrationBuilder.InsertData(
                table: "PlaceType",
                columns: new[] { "Id", "PlaceTypeDescription", "PlaceTypeName" },
                values: new object[] { 1, "abcxyz", "abcxyz" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Adress", "Email", "Password", "PhoneNumber", "Status", "UserName", "UserType" },
                values: new object[,]
                {
                    { 1, "hanoi", "abc123@gmail.com", "123456", "0123456789", 0, "user1", 1 },
                    { 2, "hanoi", "abc123@gmail.com", "123456", "0123456789", 0, "user2", 1 },
                    { 3, "hanoi", "abc123@gmail.com", "123456", "0123456789", 0, "user3", 1 }
                });

            migrationBuilder.InsertData(
<<<<<<<< HEAD:DataAccess/Migrations/20220526152755_init.cs
                table: "Place",
                columns: new[] { "Id", "Address", "BookingId", "CityId", "Image", "Latitude", "Longtitude", "PlaceName", "PlaceTypeId", "ShortDicription", "Thumb" },
                values: new object[] { 1, "hanoi", 1, null, "ljfasdkjf", 21.0278m, 105.8342m, "abc123", null, "kald;sf voiwejp", "adsfasdva" });

            migrationBuilder.CreateIndex(
                name: "IX_Place_BookingId",
========
>>>>>>>> TrungNH:DataAccess/Migrations/20220527043344_v1.cs
                table: "Place",
                columns: new[] { "Id", "Address", "CurrentCityId", "CurrentPlaceTypeId", "Image", "Latitude", "Longtitude", "PlaceName", "ShortDicription", "Thumb" },
                values: new object[] { 1, "hoan kiem, ha noi", 1, 1, "abcxyz", 21.0278m, 105.8342m, "studio", "abcxyz", "abcxyz" });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingFromTime", "BookingToTime", "CurrentPlaceId", "Deposit", "FullName", "NumberOfAdult", "NumberOfKid", "PaymentStatus", "PhoneNumber", "Price", "Status" },
                values: new object[] { 1, new DateTime(2022, 5, 12, 11, 33, 44, 79, DateTimeKind.Local).AddTicks(9195), new DateTime(2022, 5, 17, 11, 33, 44, 79, DateTimeKind.Local).AddTicks(9180), new DateTime(2022, 6, 6, 11, 33, 44, 79, DateTimeKind.Local).AddTicks(9193), 1, 0m, "Nguyen A", 1, 3, 0, "0123456789", 50000m, 0 });

            migrationBuilder.InsertData(
                table: "PlaceDetail",
                columns: new[] { "DetailID", "AC", "CarParking", "PlaceDetailPlace", "Size", "Square", "TV", "Wifi" },
                values: new object[] { 1, true, true, 1, 3, 50, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CurrentPlaceId",
                table: "Booking",
                column: "CurrentPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_CurrentCityId",
                table: "Place",
                column: "CurrentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_CurrentPlaceTypeId",
                table: "Place",
                column: "CurrentPlaceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceDetail_PlaceDetailPlace",
                table: "PlaceDetail",
                column: "PlaceDetailPlace",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "PlaceDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PlaceType");
        }
    }
}
