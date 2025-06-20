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

    public DbSet<ManufacturerModel> Manufacturers { get; set; }

    public DbSet<Shared.Models.Vehicle.Vehicle> Vehicles { get; set; }

    public DbSet<TechnicalOverviewModel> Technicaloverviews { get; set; }

    public DbSet<ServiceOperationModel> Serviceoperations { get; set; }

    public DbSet<RefuelModel> Refuels { get; set; }

    public DbSet<OperationalActivityModel> Operationalactivities { get; set; }

    public DbSet<ReservationModel> Reservations { get; set; }

    public DbSet<CaretakeModel> Caretakes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleVersion>().ToTable("vehicleversion");

        modelBuilder.Entity<VehicleModel>().ToTable("model");

        modelBuilder.Entity<VehiclePurpose>().ToTable("vehiclepurpose");

        modelBuilder.Entity<VehicleOutfitting>().ToTable("vehicleoutfitting");

        modelBuilder.Entity<VehicleModel>().ToTable("vehicle");

        modelBuilder.Entity<ManufacturerModel>().ToTable("manufacturer");

        modelBuilder.Entity<TechnicalOverviewModel>().ToTable("technicaloverview");

        modelBuilder.Entity<Serviceoperation>().ToTable("serviceoperations");
        modelBuilder.Entity<ServiceOperationModel>().ToTable("serviceoperation");

        modelBuilder.Entity<RefuelModel>().ToTable("refuel");

        modelBuilder.Entity<OperationalActivityModel>().ToTable("operationalactivities");

        modelBuilder.Entity<ReservationModel>().ToTable("reservations");

        modelBuilder.Entity<CaretakeModel>().ToTable("caretake");
    }
}
