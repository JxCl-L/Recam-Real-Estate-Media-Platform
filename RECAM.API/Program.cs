using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RECAM.API.Middlewares;
using RECAM.DataAccess.Configurations;
using RECAM.DataAccess.Data;
using RECAM.Models.Entities;
using RECAM.Repository.Interfaces;
using RECAM.Repository.Repositories;

// BUILDER CONFIG
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // 让 Swagger 能扫到 endpoint
builder.Services.AddSwaggerGen(); // 注册 Swagger Generator 生成器

// add dbcontext for sql server
builder.Services.AddDbContext<RECAMDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // password config
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    // email conifg
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<RECAMDbContext>().AddDefaultTokenProviders();
// add dbcontext for mongodb
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>();

// DI register for repo interface and concrete class
builder.Services.AddScoped<IUserActivityLogRepository, UserActivityLogRepository>();
builder.Services.AddScoped<ICaseHistoryRepository, CaseHistoryRepository>();

// BUILDER => APP

var app = builder.Build();

// APP CONFIG

app.UseMiddleware<ExceptionMiddleware>(); // after Build, before other Use

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // 提供 /swagger/v1/swagger.json
    app.UseSwaggerUI();       // 提供 /swagger 网页
}

app.UseHttpsRedirection();

app.MapControllers(); // after UseHttpsRedirection


app.Run();

