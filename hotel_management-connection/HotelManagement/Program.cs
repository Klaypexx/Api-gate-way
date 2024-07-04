using Application.Hotels.Entities;
using Application.Hotels.Repositories;
using Application.Hotels.Services;
using Domain.Configurations.Entities;
using Infrastructure;

var builder = WebApplication.CreateBuilder( args );

IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddScoped<IHotelRepository, HotelApiClient>();
services.AddScoped<IHotelService, HotelService>();

HotelApiDomain hotelApiDomain = configuration.GetSection("HotelApiDomain").Get<HotelApiDomain>();
services.AddScoped(sp => hotelApiDomain);

services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
