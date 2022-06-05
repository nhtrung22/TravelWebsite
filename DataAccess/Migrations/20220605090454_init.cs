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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ShortDicription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longtitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PlaceTypeID = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Place_PlaceType_PlaceTypeID",
                        column: x => x.PlaceTypeID,
                        principalTable: "PlaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    PlaceId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "PlaceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wifi = table.Column<bool>(type: "bit", nullable: false),
                    TV = table.Column<bool>(type: "bit", nullable: false),
                    AC = table.Column<bool>(type: "bit", nullable: false),
                    CarParking = table.Column<bool>(type: "bit", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Square = table.Column<int>(type: "int", nullable: false),
                    PlaceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceDetail_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "Description" },
                values: new object[,]
                {
                    { 1, "ha noi", "abcxyz" },
                    { 2, "tp hcm", "xyzabc" }
                });

            migrationBuilder.InsertData(
                table: "PlaceType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "abcxyz", "abcxyz" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "Password", "PasswordHash", "PhoneNumber", "Status", "UserName", "UserType" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "hanoi", "abc1236@gmail.com", "123456", "$2a$11$r02G1dKbL6TT3ApYDwTCfOP4HbpPNF9g/mNduZOnabBgWNgpzh/UC", "0123456789", 0, "user3", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "hanoi", "abc1234@gmail.com", "123456", "$2a$11$5rL2GXZHjet95w7Z2emPsuDHuXZ91b0oBOanVQG8oaf/xPRdMU1W6", "0123456789", 0, "user2", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "hanoi", "abc123@gmail.com", "123456", "$2a$11$Ik17igTBD01.x8BCwnzzveKwMMid0M6C.3hyeoHHLtL3O5Pmw1uzS", "0123456789", 0, "user1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Image", "Latitude", "Longtitude", "Name", "PlaceTypeID", "ShortDicription", "Thumb" },
                values: new object[] { 1, "bac tu liem", 1, "1", 21.0278m, 105.8342m, "studio", 1, "abcxyz", "1" });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Image", "Latitude", "Longtitude", "Name", "PlaceTypeID", "ShortDicription", "Thumb" },
                values: new object[] { 2, "hoan kiem", 1, "1", 21.0278m, 105.8342m, "penhouse", 1, "abcxyz", "1" });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Image", "Latitude", "Longtitude", "Name", "PlaceTypeID", "ShortDicription", "Thumb" },
                values: new object[] { 3, "quan 1", 2, "1", 21.0278m, 105.8342m, "palace", 1, "abcxyz", "1" });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "BookingFromTime", "BookingToTime", "Deposit", "FullName", "NumberOfAdult", "NumberOfKid", "PaymentStatus", "PhoneNumber", "PlaceId", "Price", "Status" },
                values: new object[] { 1, new DateTime(2022, 5, 21, 16, 4, 54, 22, DateTimeKind.Local).AddTicks(8487), new DateTime(2022, 5, 26, 16, 4, 54, 22, DateTimeKind.Local).AddTicks(8467), new DateTime(2022, 6, 15, 16, 4, 54, 22, DateTimeKind.Local).AddTicks(8484), 0m, "Nguyen A", 1, 3, 2, "0123456789", 1, 50000m, 0 });

            migrationBuilder.InsertData(
                table: "PlaceDetail",
                columns: new[] { "Id", "AC", "CarParking", "PlaceID", "Size", "Square", "TV", "Wifi" },
                values: new object[] { 1, true, true, 1, 3, 50, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PlaceId",
                table: "Booking",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_CityId",
                table: "Place",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_PlaceTypeID",
                table: "Place",
                column: "PlaceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceDetail_PlaceID",
                table: "PlaceDetail",
                column: "PlaceID",
                unique: true);

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
                name: "PlaceDetail");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "PlaceType");
        }
    }
}
