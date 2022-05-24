using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LibraryAPI.Data;
using LibraryAPI.Data.Repositories;
using LibraryAPI.Models;
using LibraryAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryAPIContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<BookInfo, int>, BookInfoRepository>();
builder.Services.AddScoped<ICrudRepository<BookStock, int>, BookStockRepository>();
builder.Services.AddScoped<ICrudService<BookInfo, int>, BookInfoService>();
builder.Services.AddScoped<ICrudService<BookStock, int>, BookStockService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "LibraryAPI",
        Version =
    "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();