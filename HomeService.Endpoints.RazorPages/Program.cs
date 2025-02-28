using App.Domain.AppServices.HomeService.Category;
using App.Domain.AppServices.HomeService.City;
using App.Domain.AppServices.HomeService.Comment;
using App.Domain.AppServices.HomeService.Dashboard;
using App.Domain.AppServices.HomeService.Request;
using App.Domain.AppServices.HomeService.ServiceCategory;
using App.Domain.AppServices.HomeService.SubCategory;
using App.Domain.AppServices.HomeService.Suggestion;
using App.Domain.AppServices.HomeService.User;
using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Data;
using App.Domain.Core.HomeService.CategoryEntity.Service;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Data;
using App.Domain.Core.HomeService.CityEntity.Service;
using App.Domain.Core.HomeService.CommentEntity.AppService;
using App.Domain.Core.HomeService.CommentEntity.Data;
using App.Domain.Core.HomeService.CommentEntity.Service;
using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.DashboardEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ImageEntity.Data;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Data;
using App.Domain.Core.HomeService.SubCategoryEntity.Service;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Data;
using App.Domain.Core.HomeService.SuggestionEntity.Service;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Data;
using App.Domain.Core.HomeService.UserEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.Service;
using App.Domain.Services.HomeService.Category;
using App.Domain.Services.HomeService.City;
using App.Domain.Services.HomeService.Comment;
using App.Domain.Services.HomeService.Image;
using App.Domain.Services.HomeService.Request;
using App.Domain.Services.HomeService.ServiceCategory;
using App.Domain.Services.HomeService.SubCategory;
using App.Domain.Services.HomeService.Suggestion;
using App.Domain.Services.HomeService.User;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.HomeService.Category;
using App.Infra.Data.Repos.Ef.HomeService.City;
using App.Infra.Data.Repos.Ef.HomeService.Comment;
using App.Infra.Data.Repos.Ef.HomeService.Expert;
using App.Infra.Data.Repos.Ef.HomeService.Image;
using App.Infra.Data.Repos.Ef.HomeService.Request;
using App.Infra.Data.Repos.Ef.HomeService.Service;
using App.Infra.Data.Repos.Ef.HomeService.SubCategory;
using App.Infra.Data.Repos.Ef.HomeService.Suggestion;
using App.Infra.Data.Repos.Ef.HomeService.User;
using Framework;
using HomeService.Endpoints.RazorPages.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection("SiteSettings").Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection));



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection)
.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));




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
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();
;



    builder.Host.ConfigureLogging(o => {
        o.ClearProviders();
        o.AddSerilog();
    }).UseSerilog((context, config) =>
    {
        config.WriteTo.Seq("http://localhost:5341", apiKey: "N1C3WgdFG0vkWdpe6px7");
    });


builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDashboardAppService, DashboardAppService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityAppService, CityAppService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
builder.Services.AddScoped<IServiceCategoryAppService, ServiceCategoryAppService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<ISuggestionService, SuggestionService>();
builder.Services.AddScoped<ISuggestionAppService, SuggestionAppService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();







var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseErrorLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseSerilogRequestLogging();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
