using FleetManager.Server.DataAccess.DbContexts;
using FleetManager.Server.DataAccess.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Shared.Contracts.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

string connStr = builder.Configuration.GetConnectionString("mariadb") ?? string.Empty;
builder.Services.AddMySqlDataSource(connStr);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAddressQuery, AddressQuery>();
builder.Services.AddScoped<ICaretakeQuery, CaretakeQuery>();
builder.Services.AddScoped<IContactInfoQuery, ContactInfoQuery>();
builder.Services.AddScoped<IEmployeeQuery, EmployeeQuery>();
builder.Services.AddScoped<IManufacturerQuery, ManufacturerQuery>();
builder.Services.AddScoped<IOperationalActivityQuery, OperationalActivityQuery>();
builder.Services.AddScoped<IRefuelQuery, RefuelQuery>();
builder.Services.AddScoped<IReservationQuery, ReservationQuery>();
builder.Services.AddScoped<IServiceOperationsQuery, ServiceOperationsQuery>();
builder.Services.AddScoped<ITechnicalOverviewQuery, TechnicalOverviewQuery>();
builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<IVehicleModelQuery, VehicleModelQuery>();
builder.Services.AddScoped<IVehicleOutfittingQuery, VehicleOutfittingQuery>();
builder.Services.AddScoped<IVehiclePurposeQuery, VehiclePurposeQuery>();
builder.Services.AddScoped<IVehicleQuery, VehicleQuery>();
builder.Services.AddScoped<IVehicleVersionQuery, VehicleVersionQuery>();

builder.Services.AddDbContext<EmployeeContext>(opt => opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));
builder.Services.AddDbContext<VehicleContext>(opt => opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
