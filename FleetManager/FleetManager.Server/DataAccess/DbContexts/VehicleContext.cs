using Microsoft.EntityFrameworkCore;
using Shared.Models.Caretake;
using Shared.Models.Manufacturer;
using Shared.Models.OperationalActivity;
using Shared.Models.Refuel;
using Shared.Models.Reservation;
using Shared.Models.ServiceOperation;
using Shared.Models.TechnicalOverview;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.DbContexts;

public class VehicleContext(DbContextOptions<VehicleContext> opt) : DbContext(opt)
{
    public DbSet<VehicleVersion> VehicleVersions { get; set; }

    public DbSet<VehicleModel> VehicleModels { get; set; }

    public DbSet<VehiclePurpose> VehiclePurposes { get; set; }

    public DbSet<VehicleOutfitting> VehicleOutfittings { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<Shared.Models.Vehicle.Vehicle> Vehicles { get; set; }

    public DbSet<TechnicalOverview> Technicaloverviews { get; set; }

    public DbSet<ServiceOperation> Serviceoperations { get; set; }

    public DbSet<Refuel> Refuels { get; set; }

    public DbSet<Operationalactivity> Operationalactivities { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Caretake> Caretakes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleVersion>().ToTable("vehicleversion");

        modelBuilder.Entity<VehicleModel>().ToTable("model");

        modelBuilder.Entity<VehiclePurpose>().ToTable("vehiclepurpose");

        modelBuilder.Entity<VehicleOutfitting>().ToTable("vehicleoutfitting");

        modelBuilder.Entity<VehicleModel>().ToTable("vehicle");

        modelBuilder.Entity<Manufacturer>().ToTable("manufacturer");

        modelBuilder.Entity<TechnicalOverview>().ToTable("technicaloverview");

        modelBuilder.Entity<ServiceOperation>().ToTable("serviceoperations");

        modelBuilder.Entity<Refuel>().ToTable("refuel");

        modelBuilder.Entity<Operationalactivity>().ToTable("operationalactivities");

        modelBuilder.Entity<Reservation>().ToTable("reservations");

        modelBuilder.Entity<Caretake>().ToTable("caretake");
    }
}
