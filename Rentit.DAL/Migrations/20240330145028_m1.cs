using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rentit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientiD = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building_no = table.Column<int>(type: "int", nullable: false),
                    Building_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Governs_GovernateId",
                        column: x => x.GovernateId,
                        principalTable: "Governs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_HostingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nighly_Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nums_Guests = table.Column<int>(type: "int", nullable: false),
                    Nums_Beds = table.Column<int>(type: "int", nullable: false),
                    Nums_Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Nums_Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Nums_Web_visitors = table.Column<int>(type: "int", nullable: false),
                    Loc_id = table.Column<int>(type: "int", nullable: false),
                    PlaceType_ID = table.Column<int>(type: "int", nullable: false),
                    PropetyTypeId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    HostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Locations_Loc_id",
                        column: x => x.Loc_id,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PlaceTypes_PlaceType_ID",
                        column: x => x.PlaceType_ID,
                        principalTable: "PlaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyStates_StateId",
                        column: x => x.StateId,
                        principalTable: "PropertyStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropetyTypeId",
                        column: x => x.PropetyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Users_HostId",
                        column: x => x.HostId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestHosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Request_StateID = table.Column<int>(type: "int", nullable: false),
                    Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nighly_Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nums_Guests = table.Column<int>(type: "int", nullable: false),
                    Nums_Beds = table.Column<int>(type: "int", nullable: false),
                    Nums_Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Nums_Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building_no = table.Column<int>(type: "int", nullable: false),
                    Building_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernateId = table.Column<int>(type: "int", nullable: false),
                    PlaceType_ID = table.Column<int>(type: "int", nullable: false),
                    PropetyTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestHosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestHosts_Governs_GovernateId",
                        column: x => x.GovernateId,
                        principalTable: "Governs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestHosts_PlaceTypes_PlaceType_ID",
                        column: x => x.PlaceType_ID,
                        principalTable: "PlaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestHosts_PropertyTypes_PropetyTypeId",
                        column: x => x.PropetyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestHosts_RequestStates_Request_StateID",
                        column: x => x.Request_StateID,
                        principalTable: "RequestStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestHosts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributesPropertyy",
                columns: table => new
                {
                    Attributes_propertyId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributesPropertyy", x => new { x.Attributes_propertyId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_AttributesPropertyy_Attributes_Attributes_propertyId",
                        column: x => x.Attributes_propertyId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributesPropertyy_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourites_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_order = table.Column<int>(type: "int", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestRents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HostID = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Request_StateID_Host = table.Column<int>(type: "int", nullable: false),
                    Request_StateID_Admin = table.Column<int>(type: "int", nullable: false),
                    Checkin_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nightly_price = table.Column<double>(type: "float", nullable: false),
                    ServiceFee = table.Column<double>(type: "float", nullable: false),
                    WebsiteFee = table.Column<double>(type: "float", nullable: false),
                    Total_price = table.Column<double>(type: "float", nullable: false),
                    StayDurationInDays = table.Column<int>(type: "int", nullable: false),
                    NumOfGuests = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestRents_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestRents_RequestStates_Request_StateID_Admin",
                        column: x => x.Request_StateID_Admin,
                        principalTable: "RequestStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestRents_RequestStates_Request_StateID_Host",
                        column: x => x.Request_StateID_Host,
                        principalTable: "RequestStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestRents_Users_HostID",
                        column: x => x.HostID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestRents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReviews_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributesRequestHost",
                columns: table => new
                {
                    Attributes_requestsId = table.Column<int>(type: "int", nullable: false),
                    RequesthostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributesRequestHost", x => new { x.Attributes_requestsId, x.RequesthostsId });
                    table.ForeignKey(
                        name: "FK_AttributesRequestHost_Attributes_Attributes_requestsId",
                        column: x => x.Attributes_requestsId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributesRequestHost_RequestHosts_RequesthostsId",
                        column: x => x.RequesthostsId,
                        principalTable: "RequestHosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgesForRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_order = table.Column<int>(type: "int", nullable: true),
                    Request_HostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgesForRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgesForRequests_RequestHosts_Request_HostId",
                        column: x => x.Request_HostId,
                        principalTable: "RequestHosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Icon_Url", "Name" },
                values: new object[,]
                {
                    { 1, "icon1.jpg", "WiFi" },
                    { 2, "icon2.jpg", "Washer" },
                    { 3, "icon3.jpg", "Extra pillows and blankets" },
                    { 4, "icon4.jpg", "Iron" },
                    { 5, "icon5.jpg", "TV" },
                    { 6, "icon6.jpg", "Air conditioning" },
                    { 7, "icon7.jpg", "Heating" },
                    { 8, "icon8.jpg", "Carbon monoxide alarm" },
                    { 9, "icon9.jpg", "kitchen essentials" },
                    { 10, "icon10.jpg", "Outdoor dining area" },
                    { 11, "icon11.jpg", "Outdoor dining area" },
                    { 12, "icon12.jpg", "BBQ grill" },
                    { 13, "icon13.jpg", "Security cameras on property" },
                    { 14, "icon14.jpg", "Smoke alarm" },
                    { 15, "icon15.jpg", "Free parking on premises" }
                });

            migrationBuilder.InsertData(
                table: "Governs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alexandria" },
                    { 3, "Giza" },
                    { 4, "Shubra El-Kheima" },
                    { 5, "Port Said" },
                    { 6, "Suez" },
                    { 7, "Luxor" },
                    { 8, "Asyut" },
                    { 9, "Aswan" },
                    { 10, "Damietta" }
                });

            migrationBuilder.InsertData(
                table: "PlaceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Room" },
                    { 2, "Entire Home" }
                });

            migrationBuilder.InsertData(
                table: "PropertyStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "Under maintainance" },
                    { 3, "Booked" },
                    { 4, "Unavailable" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Entire House/Apartment" },
                    { 2, "Private Room" },
                    { 3, "Shared Room" },
                    { 4, "Villa" },
                    { 5, "Condo" },
                    { 6, "Townhouse" },
                    { 7, "Cottage/Cabin" },
                    { 8, "Bungalow" },
                    { 9, "Chalet" },
                    { 10, "Farm stay" },
                    { 11, "Boat/Yacht" },
                    { 12, "Treehouse" },
                    { 13, "Yurt" },
                    { 14, "Tent/Campsite" },
                    { 15, "Igloo" }
                });

            migrationBuilder.InsertData(
                table: "RequestStates",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Refused" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Building_name", "Building_no", "City", "District_name", "GovernateId", "Location_url", "Street" },
                values: new object[,]
                {
                    { 1, "ABC Building", 123, "Cairo", "Downtown", 1, "https://maps.example.com/123", "Main Street" },
                    { 2, "XYZ Tower", 456, "Alexandria", "City Center", 2, "https://maps.example.com/456", "First Avenue" },
                    { 3, "Luxor Plaza", 789, "Luxor", "Riverfront", 3, "https://maps.example.com/789", "Nile Street" },
                    { 4, "Pyramid Tower", 101, "Giza", "Tourist Area", 1, "https://maps.example.com/101", "Sphinx Avenue" },
                    { 5, "Seafront Apartments", 202, "Alexandria", "Coastal Area", 2, "https://maps.example.com/202", "Corniche" },
                    { 6, "Nubian Palace", 303, "Aswan", "Historic Area", 3, "https://maps.example.com/303", "Pharaohs Road" },
                    { 7, "Nile View Towers", 404, "Cairo", "Riverside", 1, "https://maps.example.com/404", "Nile Corniche" },
                    { 8, "Haram Mall", 505, "Giza", "Commercial Area", 1, "https://maps.example.com/505", "Al-Haram Street" },
                    { 9, "Marina Towers", 606, "Alexandria", "Waterfront", 2, "https://maps.example.com/606", "Marina Road" },
                    { 10, "Cleopatra Palace", 707, "Luxor", "Ancient Area", 3, "https://maps.example.com/707", "Cleopatra Street" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FName", "Img_URL", "JoinedDate", "LName", "RoleId", "Start_HostingDate" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "user1.jpg", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", 1, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "jane.smith@example.com", "Jane", "user2.jpg", new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 2, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "alice.johnson@example.com", "Alice", "user3.jpg", new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", 2, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "bob.brown@example.com", "Bob", "user4.jpg", new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", 2, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "eva.martinez@example.com", "Eva", "user5.jpg", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", 2, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "michael.lee@example.com", "Michael", "user6.jpg", new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", 2, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "sarah.garcia@example.com", "Sarah", "user7.jpg", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", 2, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "david.rodriguez@example.com", "David", "user8.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", 2, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "emma.wilson@example.com", "Emma", "user9.jpg", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", 2, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "james.taylor@example.com", "James", "user10.jpg", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "HostId", "Loc_id", "Nighly_Price", "Nums_Bathrooms", "Nums_Bedrooms", "Nums_Beds", "Nums_Guests", "Nums_Web_visitors", "PlaceType_ID", "Property_Name", "PropetyTypeId", "StateId" },
                values: new object[,]
                {
                    { 1, "A comfortable apartment located in the heart of the city.", 3, 1, 100, 1, 1, 1, 2, 0, 1, "Cozy Apartment in Downtown", 1, 1 },
                    { 2, "A luxurious villa with a private pool and stunning views.", 2, 2, 300, 2, 3, 3, 6, 0, 2, "Spacious Villa with Pool", 2, 1 },
                    { 3, "A charming cottage located right on the beach, perfect for a romantic getaway.", 3, 3, 150, 1, 1, 2, 4, 0, 2, "Beachfront Cottage", 3, 1 },
                    { 4, "A cozy cabin nestled in the forest, perfect for nature lovers.", 4, 4, 120, 1, 1, 2, 3, 0, 2, "Rustic Cabin in the Woods", 4, 1 },
                    { 5, "A charming chalet with stunning mountain views and a relaxing hot tub.", 5, 5, 250, 2, 3, 4, 8, 0, 2, "Mountain Chalet with Hot Tub", 5, 1 },
                    { 6, "An elegant townhouse located in the historic district, within walking distance to major attractions.", 5, 6, 200, 2, 2, 2, 4, 0, 2, "Historic Townhouse in City Center", 6, 1 },
                    { 7, "A luxurious penthouse offering breathtaking views of the city skyline.", 7, 7, 500, 1, 1, 1, 2, 0, 2, "Luxury Penthouse with Panoramic Views", 7, 1 },
                    { 8, "A beautiful beach house with a private pool, perfect for a relaxing getaway.", 8, 8, 350, 2, 3, 3, 6, 0, 2, "Sunny Beach House with Pool", 8, 1 },
                    { 9, "A cozy cabin by the river with a private fishing dock, perfect for outdoor enthusiasts.", 9, 9, 180, 1, 1, 2, 4, 0, 2, "Riverside Cabin with Fishing Dock", 9, 1 },
                    { 10, "A unique eco-friendly treehouse retreat surrounded by nature, perfect for a peaceful escape.", 10, 10, 200, 1, 1, 1, 2, 0, 2, "Eco-Friendly Treehouse Retreat", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Img_URL", "Img_order", "PropertyId" },
                values: new object[,]
                {
                    { 1, "image1.jpg", 1, 1 },
                    { 2, "image2.jpg", 2, 1 },
                    { 3, "image3.jpg", 3, 2 },
                    { 4, "image4.jpg", 4, 2 },
                    { 5, "image5.jpg", 1, 3 },
                    { 6, "image6.jpg", 2, 3 },
                    { 7, "image7.jpg", 1, 4 },
                    { 8, "image8.jpg", 2, 4 },
                    { 9, "image9.jpg", 1, 5 },
                    { 10, "image10.jpg", 2, 5 },
                    { 11, "image11.jpg", 1, 6 },
                    { 12, "image12.jpg", 2, 6 },
                    { 13, "image13.jpg", 3, 7 },
                    { 14, "image14.jpg", 4, 7 },
                    { 15, "image15.jpg", 1, 8 },
                    { 16, "image16.jpg", 2, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttributesPropertyy_PropertiesId",
                table: "AttributesPropertyy",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributesRequestHost_RequesthostsId",
                table: "AttributesRequestHost",
                column: "RequesthostsId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_PropertyID",
                table: "Favourites",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserID",
                table: "Favourites",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyId",
                table: "Images",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgesForRequests_Request_HostId",
                table: "ImgesForRequests",
                column: "Request_HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GovernateId",
                table: "Locations",
                column: "GovernateId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_HostId",
                table: "Properties",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Loc_id",
                table: "Properties",
                column: "Loc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PlaceType_ID",
                table: "Properties",
                column: "PlaceType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropetyTypeId",
                table: "Properties",
                column: "PropetyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StateId",
                table: "Properties",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHosts_GovernateId",
                table: "RequestHosts",
                column: "GovernateId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHosts_PlaceType_ID",
                table: "RequestHosts",
                column: "PlaceType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHosts_PropetyTypeId",
                table: "RequestHosts",
                column: "PropetyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHosts_Request_StateID",
                table: "RequestHosts",
                column: "Request_StateID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestHosts_UserID",
                table: "RequestHosts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRents_HostID",
                table: "RequestRents",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRents_PropertyId",
                table: "RequestRents",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRents_Request_StateID_Admin",
                table: "RequestRents",
                column: "Request_StateID_Admin");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRents_Request_StateID_Host",
                table: "RequestRents",
                column: "Request_StateID_Host");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRents_UserID",
                table: "RequestRents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_PropertyID",
                table: "UserReviews",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_Userid",
                table: "UserReviews",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttributesPropertyy");

            migrationBuilder.DropTable(
                name: "AttributesRequestHost");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ImgesForRequests");

            migrationBuilder.DropTable(
                name: "RequestRents");

            migrationBuilder.DropTable(
                name: "UserReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "RequestHosts");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RequestStates");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PlaceTypes");

            migrationBuilder.DropTable(
                name: "PropertyStates");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Governs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
