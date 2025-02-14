using App.Domain.AppServices.HomeService.User;
using App.Domain.Core.HomeService.Base.Data;
using App.Domain.Core.HomeService.Category.Data;
using App.Domain.Core.HomeService.Comment.Data;
using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.Expert.Data;
using App.Domain.Core.HomeService.Request.Data;
using App.Domain.Core.HomeService.Service.Data;
using App.Domain.Core.HomeService.Service.Entities;
using App.Domain.Core.HomeService.SubCategory.Data;
using App.Domain.Core.HomeService.Suggestion.Data;
using App.Domain.Core.HomeService.User.AppService;
using App.Domain.Core.HomeService.User.Data;
using App.Domain.Core.HomeService.User.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.HomeService.Base.City;
using App.Infra.Data.Repos.Ef.HomeService.Base.Image;
using App.Infra.Data.Repos.Ef.HomeService.Category;
using App.Infra.Data.Repos.Ef.HomeService.Comment;
using App.Infra.Data.Repos.Ef.HomeService.Expert;
using App.Infra.Data.Repos.Ef.HomeService.Request;
using App.Infra.Data.Repos.Ef.HomeService.Service;
using App.Infra.Data.Repos.Ef.HomeService.SubCategory;
using App.Infra.Data.Repos.Ef.HomeService.Suggestion;
using App.Infra.Data.Repos.Ef.HomeService.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection("SiteSettings").Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection));



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection)
    .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));


builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();


builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
