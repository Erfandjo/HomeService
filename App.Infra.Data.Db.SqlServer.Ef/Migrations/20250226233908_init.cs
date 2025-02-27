using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.Data.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    VisitCount = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCompletion = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeOfCompletion = table.Column<TimeOnly>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertServiceCategory",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    SkilsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertServiceCategory", x => new { x.ExpertsId, x.SkilsId });
                    table.ForeignKey(
                        name: "FK_ExpertServiceCategory_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertServiceCategory_Services_SkilsId",
                        column: x => x.SkilsId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    StatusEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuggestedPrice = table.Column<float>(type: "real", nullable: false),
                    DeliveryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuggestionAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Expert", "EXPERT" },
                    { 3, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, null, false, "تمیزکاری" },
                    { 2, null, false, "ساختمان" },
                    { 3, null, false, "تعمیرات اشیا" },
                    { 4, null, false, "اسباب کشی و حمل بار" },
                    { 5, null, false, "خودرو" },
                    { 6, null, false, "سلامت و زیبایی" },
                    { 7, null, false, "سازمان ها و مجتمع ها" },
                    { 8, null, false, "سایر" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "تهران" },
                    { 2, "مشهد" },
                    { 3, "اصفهان" },
                    { 4, "شیراز" },
                    { 5, "تبریز" },
                    { 6, "کرج" },
                    { 7, "قم" },
                    { 8, "اهواز" },
                    { 9, "رشت" },
                    { 10, "کرمانشاه" },
                    { 11, "زاهدان" },
                    { 12, "ارومیه" },
                    { 13, "یزد" },
                    { 14, "همدان" },
                    { 15, "قزوین" },
                    { 16, "سنندج" },
                    { 17, "بندرعباس" },
                    { 18, "زنجان" },
                    { 19, "ساری" },
                    { 20, "بوشهر" },
                    { 21, "مازندران" },
                    { 22, "گرگان" },
                    { 23, "کرمان" },
                    { 24, "خرم آباد" },
                    { 25, "سمنان" },
                    { 26, "دزفول" },
                    { 27, "آبادان" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "CityId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImagePath", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterAt", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, 1, "99306a23-587d-4ef9-8495-c986786d9366", "Admin@gmail.com", false, null, null, false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEOi0aXxROXEnSkW1oXDGHAdnSsDb/e3ruGj2kDh8pcX/GVe82hfRKio0BSeDfBdpKA==", "09377507920", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(1623), 1, "bbd094bc-c3d2-4618-b214-8d51d7e45e0e", false, "Admin@gmail.com" },
                    { 2, 0, null, 4, "adcf7055-f8e4-4306-bb79-c16787b4d794", "Ali@gmail.com", false, null, null, false, null, false, null, "ALI@GMAIL.COM", "ALI", "AQAAAAIAAYagAAAAEIqjayTD+jm8o2BOhXXvHZe+H46cvBH/cMTSmePNHULKd7U7HsESjqej/7oo5sMjCA==", "09245112357", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2020), 2, "513aa469-e948-40c3-b0ed-e50b762e61ce", false, "Ali" },
                    { 3, 0, null, 2, "79dfdd3d-8772-496e-8931-b16fdcd1dbfd", "Mohsen@gmail.com", false, null, null, false, null, false, null, "MOHSEN@GMAIL.COM", "MOHSEN@GMAIL.COM", "AQAAAAIAAYagAAAAEAiRiwfth+gg8OZb2y0HzLaM3pSi5wla6TYXIuIR6xXT2ZAWDOI+qq5YrNheM4CEZQ==", "09106578542", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2038), 2, "6b94a867-9be9-45b9-bd1b-1dc201326470", false, "Mohsen@gmail.com" },
                    { 4, 0, null, 1, "5e927ff7-023b-40cc-bfb3-d7bd52751697", "Sahar@gmail.com", false, null, null, false, null, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAENa+XgWV61cgAX6yU6qKDQIz17HsTmzKTT3MBdElS/VssUFBs0es6sAtmRX4CB4CvA==", "09304578725", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2067), 2, "129cac6a-8414-4964-9542-e598c6ee61c1", false, "Sahar@gmail.com" },
                    { 5, 0, null, 1, "4beb6d8e-000d-45a0-a102-4d3fd1f0ca43", "Majd@gmail.com", false, null, null, false, null, false, null, "MAJID@GMAIL.COM", "MAJID@GMAIL.COM", "AQAAAAIAAYagAAAAEKUek6QlTBTy61oLdj2RE9NkjwtJ+Mop1Cam0kuPGuZZ5XrUTwm+wokF+eD85Qnofw==", "09206548795", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2081), 3, "1275f49c-43bd-4c5e-bc1a-72c4863cdc40", false, "Majid@gmail.com" },
                    { 6, 0, null, 1, "d3e53452-a44c-4b77-bd45-7586551cd060", "Parvane@gmail.com", false, null, null, false, null, false, null, "PARVANE@GMAIL.COM", "PARVANE@GMAIL.COM", "AQAAAAIAAYagAAAAEAedntp4kw+ujNaqXTvO5/FrIdbPzI7rVzx22WzG3TDxu2ufUbmJ4cXoWzJDqCIdTw==", "09632548785", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2101), 3, "388d1c7d-218d-435c-886d-a807f5d23c72", false, "Parvane@gmail.com" },
                    { 7, 0, null, 8, "c5ca6664-5c66-47b4-a18a-b25135afb31c", "Hasan@gmail.com", false, null, null, false, null, false, null, "HASAN@GMAIL.COM", "HASAN@GMAIL.COM", "AQAAAAIAAYagAAAAEK0lRLzaMg6Y+LoWo9p3yMSCS16Ib47+Dat6nHoJ20vXp1EDii4rRGzUtBH5quXdBQ==", "09223458712", false, new DateTime(2025, 2, 27, 3, 9, 5, 79, DateTimeKind.Local).AddTicks(2116), 3, "70a96bfb-da38-42b3-9a43-cbd89e50933d", false, "Hasan@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "ImagePath", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, false, "نظافت و پذیرایی" },
                    { 2, 1, null, false, "شستشو" },
                    { 3, 1, null, false, "کارواش و دیتیلینگ" },
                    { 4, 2, null, false, "سرمایش و گرمایش" },
                    { 5, 2, null, false, "تعمیرات ساختمان" },
                    { 6, 2, null, false, "لوله کشی" },
                    { 7, 2, null, false, "طراحی و بازسازی ساختمان" },
                    { 8, 2, null, false, "برقکاری" },
                    { 9, 2, null, false, "چوب و کابینت" },
                    { 10, 2, null, false, "خدمات شیشه ای ساختمان" },
                    { 11, 2, null, false, "باغبانی و فضای سبز" },
                    { 12, 3, null, false, "سرمایش و گرمایش" },
                    { 13, 3, null, false, "نصب و تعمیر لوازم خانگی" },
                    { 14, 3, null, false, "خدمات کامپیوتری" },
                    { 15, 3, null, false, "تعمیرات موبایل" },
                    { 16, 4, null, false, "باربری و جابجایی" },
                    { 17, 5, null, false, "خدمات و تعمیرات خودرو" },
                    { 18, 5, null, false, "کارواش و دیتیلینگ" },
                    { 19, 6, null, false, "زیبایی بانوان" },
                    { 20, 6, null, false, "پزشکی و پرستاری" },
                    { 21, 6, null, false, "حیوانات خانگی" },
                    { 22, 6, null, false, "مشاوره" },
                    { 23, 6, null, false, "پیرایش و زیبایی آقایان" },
                    { 24, 6, null, false, "تندرستی و ورزش" },
                    { 25, 7, null, false, "خدمات شرکتی" },
                    { 26, 7, null, false, "تامین نیروی انسانی" },
                    { 27, 8, null, false, "خیاطی و تعمیرات لباس" },
                    { 28, 8, null, false, "مجالس و رویدادها" },
                    { 29, 8, null, false, "آموزش" },
                    { 30, 8, null, false, "همه فن حریف" },
                    { 31, 8, null, false, "خدمات فوری" },
                    { 32, 8, null, false, "کودک" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "ExpertId", "1", 1 },
                    { 2, "ExpertId", "2", 2 },
                    { 3, "ExpertId", "3", 3 },
                    { 4, "CustomerId", "1", 4 },
                    { 5, "CustomerId", "2", 5 },
                    { 6, "CustomerId", "3", 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "UserId" },
                values: new object[,]
                {
                    { 1, "Pirozi", 5 },
                    { 2, "TehranPars", 6 },
                    { 3, "KianShahr", 7 }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Biography", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, "ارایه بهترین خدمات برای شما", 3.4f, 2 },
                    { 2, "بهترین کیفیت و پایین ترین قیمت", 4.4f, 3 },
                    { 3, "رضایت مشتریان خوشحالی ماست", 4.6f, 4 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "BasePrice", "ImagePath", "IsDeleted", "SubCategoryId", "Title", "VisitCount" },
                values: new object[,]
                {
                    { 1, 0f, null, false, 1, "سرویس عادی نظافت", 0 },
                    { 2, 0f, null, false, 1, "سرویس ویژه نظافت", 0 },
                    { 3, 0f, null, false, 1, "سرویس لوکس نظافت", 0 },
                    { 4, 0f, null, false, 1, "نظافت راه‌ پله", 0 },
                    { 5, 0f, null, false, 1, "سرویس نظافت فوری", 0 },
                    { 6, 0f, null, false, 1, "سمپاشی فضای داخلی", 0 },
                    { 7, 0f, null, false, 1, "پذیرایی", 0 },
                    { 8, 0f, null, false, 1, "کارگر ساده", 0 },
                    { 9, 0f, null, false, 2, "(شستشو در محل (مبل، موکت، فرش)", 0 },
                    { 10, 0f, null, false, 2, "قالیشویی", 0 },
                    { 11, 0f, null, false, 2, "خشکشویی", 0 },
                    { 12, 0f, null, false, 3, "سرامیک‌ خودرو", 0 },
                    { 13, 0f, null, false, 3, "کارواش نانو", 0 },
                    { 14, 0f, null, false, 3, "کارواش با آب", 0 },
                    { 15, 0f, null, false, 3, "واکس و پولیش خودرو", 0 },
                    { 16, 0f, null, false, 3, "صفرشویی خودرو", 0 },
                    { 17, 0f, null, false, 3, "موتورشویی خودرو", 0 },
                    { 18, 0f, null, false, 3, "پکیج کارواش VIP (صفرشویی VIP + واکس و پولیش سه مرحله‌ای)", 0 },
                    { 19, 0f, null, false, 3, "شفاف‌سازی چراغ خودرو", 0 },
                    { 20, 0f, null, false, 3, "احیای رنگ خودرو", 0 },
                    { 21, 0f, null, false, 3, "صافکاری و نقاشی خودرو", 0 },
                    { 22, 0f, null, false, 3, "نصب شیشه دودی خودرو در محل", 0 },
                    { 23, 0f, null, false, 2, "پرده‌شویی", 0 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "CustomerId", "DateOfCompletion", "Description", "Price", "RequestAt", "ServiceId", "Status", "TimeOfCompletion" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 5, 3), "Bana", 240, new DateTime(2025, 2, 27, 3, 9, 5, 55, DateTimeKind.Local).AddTicks(7192), 5, 3, new TimeOnly(12, 5, 0) },
                    { 2, 2, new DateOnly(2025, 4, 8), "Bana", 342, new DateTime(2025, 2, 27, 3, 9, 5, 55, DateTimeKind.Local).AddTicks(7736), 3, 5, new TimeOnly(12, 5, 0) },
                    { 3, 2, new DateOnly(2025, 8, 18), "Bana", 350, new DateTime(2025, 2, 27, 3, 9, 5, 55, DateTimeKind.Local).AddTicks(7742), 1, 4, new TimeOnly(12, 5, 0) },
                    { 4, 3, new DateOnly(2025, 4, 2), "Bana", 840, new DateTime(2025, 2, 27, 3, 9, 5, 55, DateTimeKind.Local).AddTicks(7745), 2, 2, new TimeOnly(12, 5, 0) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentAt", "CustomerId", "ExpertId", "RequestId", "StatusEnum", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 27, 3, 9, 5, 48, DateTimeKind.Local).AddTicks(8858), 1, 2, 1, 0, "عالی بود" },
                    { 2, new DateTime(2025, 2, 27, 3, 9, 5, 50, DateTimeKind.Local).AddTicks(1347), 2, 1, 2, 0, "بسیار بد اخلاق" },
                    { 3, new DateTime(2025, 2, 27, 3, 9, 5, 50, DateTimeKind.Local).AddTicks(1361), 3, 2, 3, 0, "کار بلد" },
                    { 4, new DateTime(2025, 2, 27, 3, 9, 5, 50, DateTimeKind.Local).AddTicks(1364), 1, 3, 4, 0, "حیف پولی که بهت دادم" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Path", "RequestId" },
                values: new object[,]
                {
                    { 1, "Images/trending/1.jpg", 1 },
                    { 2, "Images/trending/2.jpg", 2 },
                    { 3, "Images/trending/4.jpg", 2 },
                    { 4, "Images/trending/3.jpg", 3 },
                    { 5, "Images/trending/5.jpg", 4 },
                    { 6, "Images/trending/6.jpg", 4 }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "DeliveryDate", "Description", "ExpertId", "RequestId", "Status", "SuggestedPrice", "SuggestionAt" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 1, 1, 1, 250f, new DateTime(2025, 2, 27, 3, 9, 5, 73, DateTimeKind.Local).AddTicks(4340) },
                    { 2, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 1, 3, 250f, new DateTime(2025, 2, 27, 3, 9, 5, 73, DateTimeKind.Local).AddTicks(5357) },
                    { 3, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 2, 4, 250f, new DateTime(2025, 2, 27, 3, 9, 5, 73, DateTimeKind.Local).AddTicks(5366) },
                    { 4, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 3, 2, 250f, new DateTime(2025, 2, 27, 3, 9, 5, 73, DateTimeKind.Local).AddTicks(5370) },
                    { 5, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 4, 250f, new DateTime(2025, 2, 27, 3, 9, 5, 73, DateTimeKind.Local).AddTicks(5373) }
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
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_UserId",
                table: "Experts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertServiceCategory_SkilsId",
                table: "ExpertServiceCategory",
                column: "SkilsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RequestId",
                table: "Images",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubCategoryId",
                table: "Services",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ExpertId",
                table: "Suggestions",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_RequestId",
                table: "Suggestions",
                column: "RequestId");
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertServiceCategory");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
