using Domain.Hotels.Repositories;
using Infrastructure;
using Infrastructure.Database;
using Infrastructure.Foundation.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddScoped<IHotelRepository, EFHotelRepository>();

string connectionString = builder.Configuration.GetConnectionString("HotelManagement");
services.AddDbContext<HotelManagementDbContext>(o =>
{
    o.UseSqlServer(connectionString,
        ob => ob.MigrationsAssembly(typeof(HotelManagementDbContext).Assembly.FullName));
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
