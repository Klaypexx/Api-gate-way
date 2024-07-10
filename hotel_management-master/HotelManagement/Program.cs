using Application.Foundation.Entities;
using Application.Hotels.Entities;
using Application.Hotels.Repositories;
using Application.Hotels.Services;
using HotelManagement.Auth;
using Infrastructure.Database;
using Infrastructure.Foundation;
using Infrastructure.Hotels.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder( args );

IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddScoped<IHotelRepository, HotelRepository>();
services.AddScoped<IHotelService, HotelService>();
services.AddScoped<IUnitOfWork, UnitOfWork>();


string connectionString = builder.Configuration.GetConnectionString("HotelManagement");

services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);

services.AddDbContext<HotelManagementDbContext>(options => options.UseSqlServer(connectionString));

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
    
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseAuthorization();*/

app.MapControllers();

app.Run();
