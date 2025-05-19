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

    public DbSet<Technicaloverview> Technicaloverviews { get; set; }

    public DbSet<Serviceoperation> Serviceoperations { get; set; }

    public DbSet<Refuel> Refuels { get; set; }

    public DbSet<Operationalactivity> Operationalactivities { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Caretake> Caretakes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicleversion>().ToTable("vehicleversion");

        modelBuilder.Entity<VehicleModel>().ToTable("model");

        modelBuilder.Entity<Vehiclepurpose>().ToTable("vehiclepurpose");

        modelBuilder.Entity<Vehicleoutfitting>().ToTable("vehicleoutfitting");

        modelBuilder.Entity<Vehicle>().ToTable("vehicle");

        modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");

        modelBuilder.Entity<Technicaloverview>().ToTable("technicaloverview");

        modelBuilder.Entity<Serviceoperation>().ToTable("serviceoperation");

        modelBuilder.Entity<Refuel>().ToTable("refuel");

        modelBuilder.Entity<Operationalactivity>().ToTable("operationalactivities");

        modelBuilder.Entity<Reservation>().ToTable("reservations");

        modelBuilder.Entity<Caretake>().ToTable("caretake");
    }
}
