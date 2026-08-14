using RECAM.API.Middlewares;

// BUILDER CONFIG
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// BUILDER => APP

var app = builder.Build();

// APP CONFIG

app.UseMiddleware<ExceptionMiddleware>(); // after Build, before other Use

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {

// }

app.UseHttpsRedirection();

app.MapControllers(); // after UseHttpsRedirection


app.Run();

