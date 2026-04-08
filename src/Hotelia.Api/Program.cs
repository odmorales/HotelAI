using FluentValidation;
using Hotelia.Application.Hotels.Abstractions;
using Hotelia.Application.Hotels.CreateHotel;
using Hotelia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateHotelCommandValidator>();
builder.Services.AddScoped<IValidator<CreateHotelCommand>, CreateHotelCommandValidator>();

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=(localdb)\\mssqllocaldb;Database=HoteliaDb;Trusted_Connection=true;";

builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(connectionString));

// Application Services
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<CreateHotelCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
