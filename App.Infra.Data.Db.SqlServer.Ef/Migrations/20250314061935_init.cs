﻿using System;
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
                    Balance = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    BasePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Price = table.Column<int>(type: "int", nullable: false),
                    AcceptedExpertId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Requests_Experts_AcceptedExpertId",
                        column: x => x.AcceptedExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
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
                    Star = table.Column<int>(type: "int", nullable: false),
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
                    SuggestedPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, "\\Images\\Category\\df97889b-19b7-4bd4-9bd6-ab24ba2df64e170186481.jpg", false, "تمیزکاری" },
                    { 2, "\\Images\\Category\\29727be9-976b-4cdc-894d-c54519ffe8a4Sakhteman.jpg", false, "ساختمان" },
                    { 3, "\\Images\\Category\\eb660482-afd7-4ddb-8cfc-c06105e95900TamiratAshiya.jpg", false, "تعمیرات اشیا" },
                    { 4, "\\Images\\Category\\812cef5c-a6fa-4b90-9575-226a430b2b98AsbabKeshi.jpg", false, "اسباب کشی و حمل بار" },
                    { 5, "\\Images\\Category\\c6a10cce-101c-4184-a558-ee932c1f073eKhodro.jpg", false, "خودرو" },
                    { 6, "\\Images\\Category\\50c993b5-d39b-4cfa-b0a3-184b1a127866SalamatZibaii.jpg", false, "سلامت و زیبایی" },
                    { 7, "\\Images\\Category\\a77551f4-cc95-4903-a85b-0285fe347d63Sazman.jpg", false, "سازمان ها و مجتمع ها" },
                    { 8, "\\Images\\Category\\2798b1dd-de02-4490-8265-bee8ed56ad4cSayer.png", false, "سایر" }
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
                    { 1, 0, "0", 1, "7ca6661c-7c41-4f83-ac72-1997cdd8ae71", "Admin@gmail.com", false, null, null, false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAECs/ZPh/oEs8y9D3bZzJT1qfJlCH3gstNO/1/S58Cg2aTwET17ukFp27dpyssJl8uw==", "09377507920", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2177), 1, "65b1a496-a8ab-496c-807f-dac412d1321c", false, "Admin@gmail.com" },
                    { 2, 0, "0", 4, "878608d9-e65c-4455-b01a-69f53d589d1e", "Ali@gmail.com", false, null, null, false, null, false, null, "ALI@GMAIL.COM", "ALI", "AQAAAAIAAYagAAAAEB7u0G7N2GkHO57l5cAZk54ksLqTLrJxTuRENOFMSDAzJRCveG0d6Ah9lsE600bRfQ==", "09245112357", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2571), 2, "12391741-0a22-458c-8d52-16d90b1fbd9a", false, "Ali" },
                    { 3, 0, "0", 2, "1b37fc7e-2247-4176-bd61-4fe4b68647ec", "Mohsen@gmail.com", false, null, null, false, null, false, null, "MOHSEN@GMAIL.COM", "MOHSEN@GMAIL.COM", "AQAAAAIAAYagAAAAEPOeWZNf0aFagNMl8ttd+knemVXU4b7zNP5xCSmO8bAMBgYuPtQq4voQNiI2Lvd6Ig==", "09106578542", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2603), 2, "9810e837-3275-4224-8c88-e3bd3d382489", false, "Mohsen@gmail.com" },
                    { 4, 0, "0", 1, "d50e326a-5a51-42f3-9f38-1ea80a238c36", "Sahar@gmail.com", false, null, null, false, null, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAENhPcDt2Rv/1/h47XFaS+OwOlc+SHkdHqcO2GIyPtrv/hb67umAcLVSb2XCtX9vYGQ==", "09304578725", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2618), 2, "8a7e274b-4e4f-4b35-99aa-bceb4bdfa034", false, "Sahar@gmail.com" },
                    { 5, 0, "0", 1, "a40c94c9-58a3-4423-aee3-fd3be4503a2a", "Majd@gmail.com", false, null, null, false, null, false, null, "MAJID@GMAIL.COM", "MAJID@GMAIL.COM", "AQAAAAIAAYagAAAAEMDUKuwwXGbMV/PbkZR7mTgedAN6kHsGkuvPCBatcxCQV0Uv8F+LVLz9sa2bK+YJeA==", "09206548795", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2633), 3, "6cd982e7-d139-4505-a113-e4e8c4a39503", false, "Majid@gmail.com" },
                    { 6, 0, "0", 1, "66e020fd-6ee7-41b0-9e33-9a1d9f8ba46b", "Parvane@gmail.com", false, null, null, false, null, false, null, "PARVANE@GMAIL.COM", "PARVANE@GMAIL.COM", "AQAAAAIAAYagAAAAEHgBWSlelY0wunWWcs2BBsgQxzJRB3/C9l/zOcda7JYanKTwHEq/rM4e4rmzYeYubw==", "09632548785", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2658), 3, "9aed9e90-5ab0-46de-9331-fe42fe77dfdf", false, "Parvane@gmail.com" },
                    { 7, 0, "0", 8, "98d82ffd-62f3-4cef-a3b2-533c3a5e5533", "Hasan@gmail.com", false, null, null, false, null, false, null, "HASAN@GMAIL.COM", "HASAN@GMAIL.COM", "AQAAAAIAAYagAAAAEK/oo2bKNkljAsbNQ+uM0OW7uxTt/p2RwJykN0md1EBdEkwJCBj21AiMJL2MkxpBlQ==", "09223458712", false, new DateTime(2025, 3, 14, 9, 49, 34, 488, DateTimeKind.Local).AddTicks(2678), 3, "81b62c97-53bc-461b-9ab1-f45b1a4552eb", false, "Hasan@gmail.com" }
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
                    { 1, "ExpertId", "1", 2 },
                    { 2, "ExpertId", "2", 3 },
                    { 3, "ExpertId", "3", 4 },
                    { 4, "CustomerId", "1", 5 },
                    { 5, "CustomerId", "2", 6 },
                    { 6, "CustomerId", "3", 7 }
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
                columns: new[] { "Id", "BasePrice", "Description", "ImagePath", "IsDeleted", "SubCategoryId", "Title", "VisitCount" },
                values: new object[,]
                {
                    { 1, "12000000", "\r\nتوضیحات: سرویس نظافت معمولی برای حفظ تمیزی روزمره منزل یا محل کار. شامل گردگیری، جارو کردن، تی کشیدن و نظافت سطوح می‌شود.\r\n\r\nمزایا: مناسب برای افرادی که به دنبال حفظ نظافت پایه‌ای هستند.", null, false, 1, "سرویس عادی نظافت", 0 },
                    { 2, "350000", "توضیحات: نظافت عمیق و دقیق برای مناطقی که نیاز به توجه بیشتری دارند. شامل تمیز کردن نقاط سخت‌دسترس، نظافت مبلمان و سطوح با دقت بالا.\r\n\r\nمزایا: ایده‌آل برای مواقعی که نیاز به تمیزی بیشتر و جزئی‌نگرانه‌تر دارید.\r\n\r\n", null, false, 1, "سرویس ویژه نظافت", 0 },
                    { 3, "12000000", "توضیحات: سرویس نظافتی با بالاترین استانداردها و استفاده از مواد شوینده لوکس و تجهیزات پیشرفته. شامل نظافت کامل و براق‌سازی سطوح.\r\n\r\nمزایا: مناسب برای منازل و دفاتر لوکس که به دنبال بهترین کیفیت هستند.", null, false, 1, "سرویس لوکس نظافت", 0 },
                    { 4, "1400000", "توضیحات: سرویس اختصاصی برای تمیز کردن و براق‌سازی راه‌پله‌ها، شامل پاک‌کردن لکه‌ها و گردگیری کامل.\r\n\r\nمزایا: مناسب برای ساختمان‌های مسکونی و اداری با راه‌پله‌های زیاد.", null, false, 1, "نظافت راه‌ پله", 0 },
                    { 5, "210000", "توضیحات: سرویس سریع و بدون نیاز به وقت‌گیری قبلی برای مواقع اضطراری که نیاز به نظافت فوری دارید.\r\n\r\nمزایا: مناسب برای مهمانی‌های ناگهانی یا بازدیدهای غیرمنتظره.", null, false, 1, "سرویس نظافت فوری", 0 },
                    { 6, "2100000", "توضیحات: سرویس سمپاشی برای از بین بردن حشرات موذی در فضای داخلی منزل یا محل کار. استفاده از مواد ایمن و موثر.\r\n\r\nمزایا: ایجاد محیطی سالم و عاری از حشرات.", null, false, 1, "سمپاشی فضای داخلی", 0 },
                    { 7, "2400000", "توضیحات: ارائه نیروی کار ساده برای انجام کارهای سبک مانند جابجایی وسایل، نظافت اولیه و کمک در امور روزمره.\r\n\r\nمزایا: مناسب برای مواقعی که نیاز به کمک فوری دارید.", null, false, 1, "پذیرایی", 0 },
                    { 8, "2100000", "توضیحات: سرویس شستشوی حرفه‌ای مبلمان، موکت و فرش در محل شما، بدون نیاز به جابجایی وسایل.\r\n\r\nمزایا: صرفه‌جویی در زمان و حفظ کیفیت وسایل.", null, false, 1, "کارگر ساده", 0 },
                    { 9, "250000", "توضیحات: سرویس شستشوی حرفه‌ای مبلمان، موکت و فرش در محل شما، بدون نیاز به جابجایی وسایل. استفاده از دستگاه‌های پیشرفته و مواد شوینده مناسب برای هر نوع پارچه.\r\n\r\nمزایا:\r\n\r\nصرفه‌جویی در زمان و انرژی.\r\n\r\nجلوگیری از آسیب‌های ناشی از جابجایی.\r\n\r\nمناسب برای خانواده‌های شلوغ یا افرادی که وقت کافی برای نظافت ندارند.", null, false, 2, "(شستشو در محل (مبل، موکت، فرش)", 0 },
                    { 10, "241555", "توضیحات: سرویس شستشوی تخصصی فرش‌ها با دستگاه‌های مدرن و مواد شوینده مخصوص. این سرویس شامل ضدعفونی و خوشبوسازی فرش نیز می‌شود.\r\n\r\nمزایا:\r\n\r\nاز بین بردن لکه‌های سخت و عمیق.\r\n\r\nافزایش عمر فرش و حفظ رنگ آن.\r\n\r\nمناسب برای فرش‌های دست‌باف و ماشینی.", null, false, 2, "قالیشویی", 0 },
                    { 11, "12000000", "توضیحات: سرویس خشکشویی حرفه‌ای برای لباس‌ها و پارچه‌های ظریف که نیاز به شستشوی خاص دارند.\r\n\r\nمزایا: مناسب برای لباس‌های گران‌قیمت و حساس.", null, false, 2, "خشکشویی", 0 },
                    { 12, "1400000", "توضیحات: سرویس براق‌سازی و محافظت از سرامیک خودرو برای افزایش طول عمر و زیبایی آن.\r\n\r\nمزایا: محافظت از رنگ و بدنه خودرو در برابر عوامل محیطی.", null, false, 3, "سرامیک‌ خودرو", 0 },
                    { 13, "4100000", "\r\nتوضیحات: استفاده از فناوری نانو برای شستشو و محافظت از بدنه خودرو، ایجاد لایه‌ای ضد خش و ضد آب.\r\n\r\nمزایا: افزایش درخشندگی و محافظت طولانی‌مدت.", null, false, 3, "کارواش نانو", 0 },
                    { 14, "2700000", "\r\nتوضیحات: سرویس شستشوی خودرو با استفاده از آب و مواد شوینده مخصوص، برای تمیز کردن بدنه، شیشه‌ها، چرخ‌ها و سایر قسمت‌های بیرونی خودرو. این سرویس به صورت حرفه‌ای و با دقت بالا انجام می‌شود.\r\n\r\nمزایا:\r\n\r\nاز بین بردن گرد و غبار، لکه‌ها و آلودگی‌های سطحی.\r\n\r\nمناسب برای شستشوی سریع و روزمره خودرو.\r\n\r\nافزایش زیبایی ظاهری خودرو در کمترین زمان.", null, false, 3, "کارواش با آب", 0 },
                    { 15, "2100000", "\r\nتوضیحات: سرویس تخصصی واکس و پولیش خودرو برای بازگرداندن درخشش و زیبایی اولیه بدنه خودرو. این سرویس شامل پولیش برای از بین بردن خش‌های سطحی و واکس برای ایجاد لایه‌ای محافظ و براق‌کننده است.\r\n\r\nمزایا:\r\n\r\nمحافظت از رنگ و بدنه خودرو در برابر عوامل محیطی مانند نور خورشید، باران و آلودگی.\r\n\r\nاز بین بردن خش‌ها و لکه‌های سطحی.\r\n\r\nمناسب برای خودروهای قدیمی که نیاز به احیا دارند.", null, false, 3, "واکس و پولیش خودرو", 0 },
                    { 16, "140000", "توضیحات: سرویس نظافت کامل خودرو از داخل و خارج، شامل شستشوی موتور و زیر خودرو.\r\n\r\nمزایا: مناسب برای خودروهای نو یا خودروهایی که نیاز به نظافت کامل دارند.", null, false, 3, "صفرشویی خودرو", 0 },
                    { 17, "1700000", "\r\nتوضیحات: سرویس شستشوی موتور خودرو برای افزایش کارایی و زیبایی آن.\r\n\r\nمزایا: افزایش طول عمر موتور و بهبود عملکرد.", null, false, 3, "موتورشویی خودرو", 0 },
                    { 18, "1400000", "توضیحات: سرویس ویژه برای خودروهای لوکس، شامل صفرشویی کامل، واکس و پولیش سه مرحله‌ای.\r\n\r\nمزایا: مناسب برای خودروهای گران‌قیمت که نیاز به مراقبت ویژه دارند", null, false, 3, "پکیج کارواش VIP (صفرشویی VIP + واکس و پولیش سه مرحله‌ای)", 0 },
                    { 19, "1000000", "توضیحات: سرویس بازگرداندن شفافیت چراغ‌های خودرو که به مرور زمان کدر شده‌اند.\r\n\r\nمزایا: بهبود دید در شب و افزایش ایمنی.", null, false, 3, "شفاف‌سازی چراغ خودرو", 0 },
                    { 20, "2700000", "\r\nتوضیحات: سرویس بازگرداندن رنگ اصلی خودرو و از بین بردن خش‌ها و لکه‌های سطحی.\r\n\r\nمزایا: افزایش زیبایی و ارزش خودرو.", null, false, 3, "احیای رنگ خودرو", 0 },
                    { 21, "2100000", "توضیحات: سرویس تخصصی صافکاری و نقاشی خودرو برای رفع خراش‌ها و آسیب‌های بدنه.\r\n\r\nمزایا: بازگرداندن ظاهر اولیه خودرو.", null, false, 3, "صافکاری و نقاشی خودرو", 0 },
                    { 22, "2100000", "\r\nتوضیحات: سرویس نصب شیشه دودی با کیفیت بالا برای افزایش حریم خصوصی و کاهش حرارت داخل خودرو.\r\n\r\nمزایا: بهبود ظاهر و راحتی خودرو.", null, false, 3, "نصب شیشه دودی خودرو در محل", 0 },
                    { 23, "15420000", "\r\nتوضیحات: سرویس شستشوی حرفه‌ای پرده‌ها در محل شما یا در کارگاه تخصصی. این سرویس شامل شستشو، ضدعفونی و اتوکشی پرده‌ها می‌شود.\r\n\r\nمزایا:\r\n\r\nحفظ بافت و رنگ پرده‌ها.\r\n\r\nمناسب برای پرده‌های ظریف و حساس.\r\n\r\nصرفه‌جویی در زمان و هزینه.", null, false, 2, "پرده‌شویی", 0 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "AcceptedExpertId", "CustomerId", "DateOfCompletion", "Description", "Price", "RequestAt", "ServiceId", "Status", "TimeOfCompletion" },
                values: new object[,]
                {
                    { 1, null, 1, new DateOnly(2025, 5, 3), "Bana", 240, new DateTime(2025, 3, 14, 9, 49, 34, 480, DateTimeKind.Local).AddTicks(1711), 5, 1, new TimeOnly(12, 5, 0) },
                    { 2, null, 2, new DateOnly(2025, 4, 8), "Bana", 342, new DateTime(2025, 3, 14, 9, 49, 34, 480, DateTimeKind.Local).AddTicks(2121), 3, 1, new TimeOnly(12, 5, 0) },
                    { 3, null, 2, new DateOnly(2025, 8, 18), "Bana", 350, new DateTime(2025, 3, 14, 9, 49, 34, 480, DateTimeKind.Local).AddTicks(2124), 1, 1, new TimeOnly(12, 5, 0) },
                    { 4, null, 3, new DateOnly(2025, 4, 2), "Bana", 840, new DateTime(2025, 3, 14, 9, 49, 34, 480, DateTimeKind.Local).AddTicks(2127), 2, 1, new TimeOnly(12, 5, 0) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentAt", "CustomerId", "ExpertId", "RequestId", "Star", "StatusEnum", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 14, 9, 49, 34, 474, DateTimeKind.Local).AddTicks(2065), 1, 2, 1, 5, 0, "عالی بود" },
                    { 2, new DateTime(2025, 3, 14, 9, 49, 34, 475, DateTimeKind.Local).AddTicks(4384), 2, 1, 2, 2, 0, "بسیار بد اخلاق" },
                    { 3, new DateTime(2025, 3, 14, 9, 49, 34, 475, DateTimeKind.Local).AddTicks(4401), 3, 2, 3, 4, 0, "کار بلد" },
                    { 4, new DateTime(2025, 3, 14, 9, 49, 34, 475, DateTimeKind.Local).AddTicks(4404), 1, 3, 4, 1, 0, "حیف پولی که بهت دادم" }
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
                    { 1, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 1, 1, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(6986) },
                    { 2, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 1, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7466) },
                    { 3, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 2, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7470) },
                    { 4, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 2, 3, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7472) },
                    { 5, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7474) },
                    { 6, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7478) },
                    { 7, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7480) },
                    { 8, new DateOnly(2025, 5, 2), "کار شما تخصص ماست", 3, 4, 1, "250", new DateTime(2025, 3, 14, 9, 49, 34, 483, DateTimeKind.Local).AddTicks(7482) }
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
                name: "IX_Requests_AcceptedExpertId",
                table: "Requests",
                column: "AcceptedExpertId");

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
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

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
