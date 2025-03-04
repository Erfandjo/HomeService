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
                    { 1, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\TamizKari.jpg", false, "تمیزکاری" },
                    { 2, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\Sakhteman.jpg", false, "ساختمان" },
                    { 3, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\TamiratAshiya.jpg", false, "تعمیرات اشیا" },
                    { 4, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\AsbabKeshi.jpg", false, "اسباب کشی و حمل بار" },
                    { 5, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\Khodro.jpg", false, "خودرو" },
                    { 6, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\SalamatZibaii.jpg", false, "سلامت و زیبایی" },
                    { 7, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\Sazman.jpg", false, "سازمان ها و مجتمع ها" },
                    { 8, "D:\\MaktabSharif\\FinalProject-HomeService\\HomeService\\HomeService.Endpoints.RazorPages\\wwwroot\\Images\\Category\\Sayer.png", false, "سایر" }
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
                    { 1, 0, null, 1, "59bf811a-6db9-4fe0-a2d9-a78c528574c4", "Admin@gmail.com", false, null, null, false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEMOA+ms1+mchJxeT22PmjwSrhLRjpcmRJVuzlzv9EXvIz4WTECRi7REaW5vG0ywFCw==", "09377507920", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(455), 1, "ebb1ba6d-03b2-43e0-9a4a-5f4c1191d1c9", false, "Admin@gmail.com" },
                    { 2, 0, null, 4, "1e725075-f8cc-4a6b-8513-db72915cac50", "Ali@gmail.com", false, null, null, false, null, false, null, "ALI@GMAIL.COM", "ALI", "AQAAAAIAAYagAAAAEP7jeeNgYQE44k0MKf1kDzuM7Cu+AKrl0TE0mHnakhxjn3lgkXCgczfwgGBjami+ZA==", "09245112357", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(730), 2, "90b63b57-562c-43e0-8f63-47e24d36dc4c", false, "Ali" },
                    { 3, 0, null, 2, "b0a9adda-11c5-4524-861c-698dc70d8dab", "Mohsen@gmail.com", false, null, null, false, null, false, null, "MOHSEN@GMAIL.COM", "MOHSEN@GMAIL.COM", "AQAAAAIAAYagAAAAEDv5ry0qUIopHEsMCi4gMQb7VRSELR+Cj/VazuE4yochn73khRa0RaypNbGkwdcNAw==", "09106578542", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(742), 2, "6fd3ef24-f5f9-4f9a-aa41-9013749f54b0", false, "Mohsen@gmail.com" },
                    { 4, 0, null, 1, "5ed82c2d-ada2-46c0-8a54-094644b1071e", "Sahar@gmail.com", false, null, null, false, null, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAENtt4Kd5Gpfmxvp1Ig4agGUicg1yTpQSe4gdDU2CwYeRIGhG9aX7ft1zkvf7bK7EVg==", "09304578725", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(753), 2, "2387bdbc-19f8-4b79-9128-7de31f789fbd", false, "Sahar@gmail.com" },
                    { 5, 0, null, 1, "1ae25b3d-6378-4099-b9bb-684efbc86bbe", "Majd@gmail.com", false, null, null, false, null, false, null, "MAJID@GMAIL.COM", "MAJID@GMAIL.COM", "AQAAAAIAAYagAAAAEA2fXZayIhrqba9i2H01AQUNrtvEAvmjhd0ICaUrLAZQC/QBiVwFz06gPJtYdK0HOQ==", "09206548795", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(770), 3, "bac1a043-1869-4106-b720-3108f1cce842", false, "Majid@gmail.com" },
                    { 6, 0, null, 1, "27935936-b4b3-4b41-9fbb-92f40cc2cd6e", "Parvane@gmail.com", false, null, null, false, null, false, null, "PARVANE@GMAIL.COM", "PARVANE@GMAIL.COM", "AQAAAAIAAYagAAAAEGNCvU0bs0nBQh2ReQVqs4u2duWL7ECHGBmdUxQ+NZnag/KMFE6jVPjNgOLOdODmRA==", "09632548785", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(788), 3, "688638cd-1a75-456e-baa9-73998e5a2b72", false, "Parvane@gmail.com" },
                    { 7, 0, null, 8, "d54b464a-23d4-46ac-b0b6-b08a1056b336", "Hasan@gmail.com", false, null, null, false, null, false, null, "HASAN@GMAIL.COM", "HASAN@GMAIL.COM", "AQAAAAIAAYagAAAAEFXQb2jPLhsyTaJGerRC77S4XL/bS4g1N5V0iX/TuWO0UCj6RbtMdjpQG4BTFz/Pyg==", "09223458712", false, new DateTime(2025, 3, 1, 20, 53, 41, 407, DateTimeKind.Local).AddTicks(798), 3, "f197b65e-0d0f-4aeb-9514-0334e15336fa", false, "Hasan@gmail.com" }
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
                    { 1, 1, new DateOnly(2025, 5, 3), "Bana", 240, new DateTime(2025, 3, 1, 20, 53, 41, 398, DateTimeKind.Local).AddTicks(8881), 5, 3, new TimeOnly(12, 5, 0) },
                    { 2, 2, new DateOnly(2025, 4, 8), "Bana", 342, new DateTime(2025, 3, 1, 20, 53, 41, 398, DateTimeKind.Local).AddTicks(9518), 3, 5, new TimeOnly(12, 5, 0) },
                    { 3, 2, new DateOnly(2025, 8, 18), "Bana", 350, new DateTime(2025, 3, 1, 20, 53, 41, 398, DateTimeKind.Local).AddTicks(9574), 1, 4, new TimeOnly(12, 5, 0) },
                    { 4, 3, new DateOnly(2025, 4, 2), "Bana", 840, new DateTime(2025, 3, 1, 20, 53, 41, 398, DateTimeKind.Local).AddTicks(9578), 2, 2, new TimeOnly(12, 5, 0) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentAt", "CustomerId", "ExpertId", "RequestId", "StatusEnum", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 1, 20, 53, 41, 392, DateTimeKind.Local).AddTicks(2736), 1, 2, 1, 0, "عالی بود" },
                    { 2, new DateTime(2025, 3, 1, 20, 53, 41, 393, DateTimeKind.Local).AddTicks(2956), 2, 1, 2, 0, "بسیار بد اخلاق" },
                    { 3, new DateTime(2025, 3, 1, 20, 53, 41, 393, DateTimeKind.Local).AddTicks(2968), 3, 2, 3, 0, "کار بلد" },
                    { 4, new DateTime(2025, 3, 1, 20, 53, 41, 393, DateTimeKind.Local).AddTicks(2970), 1, 3, 4, 0, "حیف پولی که بهت دادم" }
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
                    { 1, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 1, 1, 1, 250f, new DateTime(2025, 3, 1, 20, 53, 41, 403, DateTimeKind.Local).AddTicks(411) },
                    { 2, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 1, 3, 250f, new DateTime(2025, 3, 1, 20, 53, 41, 403, DateTimeKind.Local).AddTicks(1020) },
                    { 3, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 2, 4, 250f, new DateTime(2025, 3, 1, 20, 53, 41, 403, DateTimeKind.Local).AddTicks(1025) },
                    { 4, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 3, 2, 250f, new DateTime(2025, 3, 1, 20, 53, 41, 403, DateTimeKind.Local).AddTicks(1028) },
                    { 5, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 4, 250f, new DateTime(2025, 3, 1, 20, 53, 41, 403, DateTimeKind.Local).AddTicks(1030) }
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
