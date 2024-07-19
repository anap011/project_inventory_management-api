using backend_inventory_management;
using backend_inventory_management.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});
*/
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                      .AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("connection");
//var connectionString = builder.Configuration.GetValue<string>("");
//var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
var apiKey = Environment.GetEnvironmentVariable("API_KEY");

Console.WriteLine(connectionString);

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyMiddleware>(); // Aquí se añade el middleware
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
