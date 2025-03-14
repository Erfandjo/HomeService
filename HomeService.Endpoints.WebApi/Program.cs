using App.Domain.AppServices.HomeService.Customer;
using App.Domain.AppServices.HomeService.Expert;
using App.Domain.AppServices.HomeService.Request;
using App.Domain.AppServices.HomeService.ServiceCategory;
using App.Domain.AppServices.HomeService.SubCategory;
using App.Domain.AppServices.HomeService.Suggestion;
using App.Domain.AppServices.HomeService.User;
using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Data;
using App.Domain.Core.HomeService.CustomerEntity.Service;
using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ExpertEntity.Service;
using App.Domain.Core.HomeService.ImageEntity.Data;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data.EntityFramework;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Data.EntityFramework;
using App.Domain.Core.HomeService.SubCategoryEntity.Service;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Data;
using App.Domain.Core.HomeService.SuggestionEntity.Service;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Data;
using App.Domain.Core.HomeService.UserEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.Service;
using App.Domain.Services.HomeService.Customer;
using App.Domain.Services.HomeService.Expert;
using App.Domain.Services.HomeService.Image;
using App.Domain.Services.HomeService.Request;
using App.Domain.Services.HomeService.ServiceCategory;
using App.Domain.Services.HomeService.SubCategory;
using App.Domain.Services.HomeService.Suggestion;
using App.Domain.Services.HomeService.User;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.HomeService.Customer;
using App.Infra.Data.Repos.Ef.HomeService.Expert;
using App.Infra.Data.Repos.Ef.HomeService.Image;
using App.Infra.Data.Repos.Ef.HomeService.Request;
using App.Infra.Data.Repos.Ef.HomeService.Service;
using App.Infra.Data.Repos.Ef.HomeService.SubCategory;
using App.Infra.Data.Repos.Ef.HomeService.Suggestion;
using App.Infra.Data.Repos.Ef.HomeService.User;
using Framework;
using HomeService.Endpoints.WebApi.Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection("SiteSettings").Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);



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



builder.Services.AddMemoryCache();
builder.Services.AddScoped<ApiKeyFilter>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<ISuggestionService, SuggestionService>();
builder.Services.AddScoped<ISuggestionAppService, SuggestionAppService>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
builder.Services.AddScoped<IServiceCategoryAppService, ServiceCategoryAppService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<IExpertAppService, ExpertAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
