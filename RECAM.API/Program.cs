using Microsoft.EntityFrameworkCore;
using RECAM.API.Middlewares;
using RECAM.DataAccess.Data;

// BUILDER CONFIG
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // 让 Swagger 能扫到 endpoint
builder.Services.AddSwaggerGen(); // 注册 Swagger Generator 生成器

builder.Services.AddDbContext<RECAMDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

