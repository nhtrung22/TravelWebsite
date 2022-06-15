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
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
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
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PlaceTypeID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    CurrentUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_Booking_User_CurrentUserId",
                        column: x => x.CurrentUserId,
                        principalTable: "User",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "PlaceImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceImage_Place_CurrentPlaceId",
                        column: x => x.CurrentPlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityName", "Description" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "abcxyz" },
                    { 2, "TP HCM", "xyzabc" },
                    { 3, "Đà Nẵng", "xyzabc" },
                    { 4, "Quảng Ninh", "xyzabc" },
                    { 5, "Quảng Ngãi", "xyzabc" }
                });

            migrationBuilder.InsertData(
                table: "PlaceType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "abcxyz", "abcxyz" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Email", "PasswordHash", "PhoneNumber", "UserName", "UserType" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "tphcm", "abc12314121@gmail.com", "$2a$11$SCyhlFSMcaypy6U7csFKu.S5Mp7R4x3MSnSH/xuwZlh/XiwhZlzqa", "0123456789", "user1", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "tphcm", "463412@gmail.com", "$2a$11$Ss.wEWVcF9xyBJi7B.xz5uMgImxdxOfjCvDntfHjbI7DfsQ8YqqRO", "0123456789", "user2", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "hanoi", "241241@gmail.com", "$2a$11$XEZzey4TscbS7ACxqZGxTuY3J9/UwoOHohywIUN2wj8OmxqTibnOG", "0123456789", "user3", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "da nang", "abc1236187854@gmail.com", "$2a$11$78FUFTKezA9ehv4GOmCrUuDxAgakelfwHnl8voviDGZDAbrNK8DdG", "0123456789", "user4", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "da nang", "abc123618654@gmail.com", "$2a$11$OQ/MFpFp2KnmVBq1jTlhDen63eQgJMoENKwH0cOWjvz5jv8CymH1q", "0123456789", "user5", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "da nang", "abc123656714@gmail.com", "$2a$11$0OsVFPVcmpkmM2SH0otuA./oP98lccF0xNKnIqgTGKjCbW9QpLsAC", "0123456789", "user6", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "da nang", "abc123688814@gmail.com", "$2a$11$neQ8XWKq8toH1I78k80Ys.UDWq0UWQX4JqLvgsFLfyKT3b8QQKfrK", "0123456789", "user7", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "da nang", "abc125673614@gmail.com", "$2a$11$/IbjXFNwRtAsvWCYwTWNLukrPgvHz7uPiU8F8Q25UaZOaZIre4x2S", "0123456789", "user8", 1 }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "Address", "CityId", "Latitude", "Longtitude", "Name", "PlaceTypeID", "ShortDicription", "UserId" },
                values: new object[,]
                {
                    { 1, "bac tu liem", 1, 3841231423m, 6434523m, "studio", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000001") },
                    { 2, "hoan kiem", 1, 3841231423m, 6434523m, "penhouse", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000002") },
                    { 3, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000003") },
                    { 4, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000004") },
                    { 5, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000005") },
                    { 6, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000006") },
                    { 7, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000007") },
                    { 8, "quan 1", 2, 3841231423m, 6434523m, "palace", 1, "abcxyz", new Guid("00000000-0000-0000-0000-000000000008") }
                });

            migrationBuilder.InsertData(
                table: "Booking",
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
                name: "IX_Place_UserId",
                table: "Place",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceDetail_PlaceID",
                table: "PlaceDetail",
                column: "PlaceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImage_CurrentPlaceId",
                table: "PlaceImage",
                column: "CurrentPlaceId");

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
