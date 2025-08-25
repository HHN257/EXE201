using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartTravel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ToCurrency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specializations = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalReviews = table.Column<int>(type: "int", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppStoreUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PlayStoreUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AppIcon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TourGuideReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    TourGuideId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuideReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuideReviews_TourGuides_TourGuideId",
                        column: x => x.TourGuideId,
                        principalTable: "TourGuides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourGuideReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferenceKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PreferenceValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPreferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "DisplayOrder", "Icon", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Hotel booking services", 1, "hotel", true, "Accommodation" },
                    { 2, "Local transportation services", 2, "car", true, "Transportation" },
                    { 3, "Food delivery and restaurant services", 3, "restaurant", true, "Food & Dining" },
                    { 4, "Entertainment and leisure activities", 4, "entertainment", true, "Entertainment" },
                    { 5, "Inter-city transportation", 5, "bus", true, "Long Distance Travel" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyRates",
                columns: new[] { "Id", "FromCurrency", "IsActive", "LastUpdated", "Rate", "ToCurrency" },
                values: new object[,]
                {
                    { 1, "VND", true, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8774), 0.000041m, "USD" },
                    { 2, "VND", true, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8777), 0.000038m, "EUR" },
                    { 3, "VND", true, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8778), 0.0061m, "JPY" },
                    { 4, "VND", true, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8780), 0.054m, "KRW" },
                    { 5, "VND", true, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8781), 0.000032m, "GBP" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AppIcon", "AppStoreUrl", "CategoryId", "CreatedAt", "Currency", "Description", "DisplayOrder", "IsActive", "IsPopular", "MaxPrice", "MinPrice", "Name", "PlayStoreUrl", "ProviderName", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, null, null, 1, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8712), "VND", "Book hotels, flights, and activities", 1, true, true, null, null, "Traveloka", null, "Traveloka", null },
                    { 2, null, null, 1, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8721), "VND", "Travel experiences and activities", 2, true, true, null, null, "Klook", null, "Klook", null },
                    { 3, null, null, 1, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8723), "VND", "Hotel booking platform", 3, true, false, null, null, "Agoda", null, "Agoda", null },
                    { 4, null, null, 2, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8724), "VND", "Ride-hailing and food delivery", 1, true, true, null, null, "Grab", null, "Grab", null },
                    { 5, null, null, 2, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8725), "VND", "Vietnamese ride-hailing app", 2, true, false, null, null, "Be", null, "Be", null },
                    { 6, null, null, 2, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8727), "VND", "Electric taxi service", 3, true, false, null, null, "XanhSM", null, "XanhSM", null },
                    { 7, null, null, 2, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8728), "VND", "Public bus information", 4, true, false, null, null, "BusMap", null, "BusMap", null },
                    { 8, null, null, 3, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8729), "VND", "Food delivery service", 1, true, true, null, null, "GrabFood", null, "Grab", null },
                    { 9, null, null, 3, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8731), "VND", "Food delivery platform", 2, true, false, null, null, "ShopeeFood", null, "Shopee", null },
                    { 10, null, null, 3, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8733), "VND", "Food delivery service", 3, true, false, null, null, "BeFood", null, "Be", null },
                    { 11, null, null, 4, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8734), "VND", "Movie ticket booking", 1, true, false, null, null, "CGV Cinemas", null, "CGV", null },
                    { 12, null, null, 4, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8735), "VND", "Movie ticket booking", 2, true, false, null, null, "Lotte Cinema", null, "Lotte", null },
                    { 13, null, null, 5, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8736), "VND", "Inter-city bus service", 1, true, false, null, null, "Phương Trang", null, "Phương Trang", null },
                    { 14, null, null, 5, new DateTime(2025, 8, 8, 13, 56, 52, 531, DateTimeKind.Utc).AddTicks(8737), "VND", "Premium bus service", 2, true, false, null, null, "Limousine", null, "Limousine", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingReference",
                table: "Bookings",
                column: "BookingReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_FromCurrency_ToCurrency",
                table: "CurrencyRates",
                columns: new[] { "FromCurrency", "ToCurrency" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_ServiceId",
                table: "ServiceReviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReviews_UserId",
                table: "ServiceReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideReviews_TourGuideId",
                table: "TourGuideReviews",
                column: "TourGuideId");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuideReviews_UserId",
                table: "TourGuideReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "ServiceReviews");

            migrationBuilder.DropTable(
                name: "TourGuideReviews");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "TourGuides");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
