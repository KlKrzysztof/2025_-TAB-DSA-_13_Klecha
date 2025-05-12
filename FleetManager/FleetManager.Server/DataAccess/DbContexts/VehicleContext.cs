using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FleetManager.Server.DataAccess.DbContexts;

public class VehicleContext(DbContextOptions<VehicleContext> opt) : DbContext(opt)
{
    public DbSet<Vehicleversion> VehicleVersions { get; set; }

    public DbSet<VehicleModel> VehicleModels { get; set; }

    public DbSet<Vehiclepurpose> VehiclePurposes { get; set; }

    public DbSet<Vehicleoutfitting> VehicleOutfittings { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }   

    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicleversion>().ToTable("vehicleversion");

        modelBuilder.Entity<VehicleModel>().ToTable("model");

        modelBuilder.Entity<Vehiclepurpose>().ToTable("vehiclepurpose");

        modelBuilder.Entity<Vehicleoutfitting>().ToTable("vehicleoutfitting");

        modelBuilder.Entity<Vehicle>().ToTable("vehicle");

        modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");
    }
}
