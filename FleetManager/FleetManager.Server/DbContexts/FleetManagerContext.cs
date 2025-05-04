//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
//using Shared.Models;

//namespace FleetManager.Server.DbContexts;

//public partial class FleetManagerContext : DbContext
//{
//    public FleetManagerContext()
//    {
//    }

//    public FleetManagerContext(DbContextOptions<FleetManagerContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Address> Addresses { get; set; }

//    public virtual DbSet<Caretake> Caretakes { get; set; }

//    public virtual DbSet<Contactinfo> Contactinfos { get; set; }

//    public virtual DbSet<EmployeeModel> Employees { get; set; }

//    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

//    public virtual DbSet<Model> Models { get; set; }

//    public virtual DbSet<Operationalactivity> Operationalactivities { get; set; }

//    public virtual DbSet<Refuel> Refuels { get; set; }

//    public virtual DbSet<Reservation> Reservations { get; set; }

//    public virtual DbSet<Serviceoperation> Serviceoperations { get; set; }

//    public virtual DbSet<Technicaloverview> Technicaloverviews { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<Vehicle> Vehicles { get; set; }

//    public virtual DbSet<Vehicleoutfitting> Vehicleoutfittings { get; set; }

//    public virtual DbSet<Vehiclepurpose> Vehiclepurposes { get; set; }

//    public virtual DbSet<Vehicleversion> Vehicleversions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseMySql("name=ConnectionStrings:mariadb", ServerVersion.Parse("11.7.2-mariadb"));
    
//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .UseCollation("utf8mb4_uca1400_ai_ci")
//            .HasCharSet("utf8mb4");

//        modelBuilder.Entity<Address>(entity =>
//        {
//            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

//            entity.ToTable("address");

//            entity.HasIndex(e => e.EmployeeId, "address_employee_FK");

//            entity.Property(e => e.AddressId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("addressId");
//            entity.Property(e => e.AccommodationNumber)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("accommodationNumber");
//            entity.Property(e => e.City)
//                .HasMaxLength(50)
//                .HasColumnName("city");
//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.HouseNumber)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("houseNumber");
//            entity.Property(e => e.PostalCode)
//                .HasMaxLength(15)
//                .HasColumnName("postalCode");
//            entity.Property(e => e.Street)
//                .HasMaxLength(100)
//                .HasColumnName("street");

//            entity.HasOne(d => d.Employee).WithMany(p => p.Addresses)
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.SetNull)
//                .HasConstraintName("address_employee_FK");
//        });

//        modelBuilder.Entity<Caretake>(entity =>
//        {
//            entity.HasKey(e => e.CaretakeId).HasName("PRIMARY");

//            entity.ToTable("caretake");

//            entity.HasIndex(e => e.EmployeeId, "caretake_employee_FK");

//            entity.HasIndex(e => e.VehicleId, "caretake_vehicle_FK");

//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.EndDate).HasColumnName("endDate");
//            entity.Property(e => e.StartDate).HasColumnName("startDate");
//            entity.Property(e => e.VehicleId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehicleId");

//            entity.HasOne(d => d.Employee).WithMany(p => p.Caretakes)
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("caretake_employee_FK");

//            entity.HasOne(d => d.Vehicle).WithMany(p => p.Caretakes)
//                .HasForeignKey(d => d.VehicleId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("caretake_vehicle_FK");
//        });

//        modelBuilder.Entity<Contactinfo>(entity =>
//        {
//            entity.HasKey(e => e.ContactId).HasName("PRIMARY");

//            entity.ToTable("contactinfo");

//            entity.HasIndex(e => e.EmployeeId, "contactinfo_employee_FK");

//            entity.Property(e => e.ContactId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("contactId");
//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.TelNumber)
//                .HasMaxLength(15)
//                .HasColumnName("telNumber");

//            entity.HasOne(d => d.Employee).WithMany(p => p.Contactinfos)
//                .HasForeignKey(d => d.EmployeeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("contactinfo_employee_FK");
//        });

//        modelBuilder.Entity<EmployeeModel>(entity =>
//        {
//            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

//            entity.ToTable("employee");

//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.FirstName)
//                .HasMaxLength(100)
//                .HasColumnName("firstName");
//            entity.Property(e => e.Pesel)
//                .HasMaxLength(11)
//                .IsFixedLength()
//                .HasColumnName("pesel");
//            entity.Property(e => e.SecondName)
//                .HasMaxLength(100)
//                .HasColumnName("secondName");
//            entity.Property(e => e.Surname)
//                .HasMaxLength(100)
//                .HasColumnName("surname");
//        });

//        modelBuilder.Entity<Manufacturer>(entity =>
//        {
//            entity.HasKey(e => e.ManufacturerId).HasName("PRIMARY");

//            entity.ToTable("manufacturer");

//            entity.Property(e => e.ManufacturerId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("manufacturerId");
//            entity.Property(e => e.Name)
//                .HasMaxLength(100)
//                .HasColumnName("name");
//        });

//        modelBuilder.Entity<Model>(entity =>
//        {
//            entity.HasKey(e => e.ModelId).HasName("PRIMARY");

//            entity.ToTable("model");

//            entity.HasIndex(e => e.ManufacturerId, "model_manufacturer_FK");

//            entity.HasIndex(e => e.VehicleVersionId, "model_vehicleversion_FK");

//            entity.Property(e => e.ModelId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("modelId");
//            entity.Property(e => e.ManufacturerId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("manufacturerId");
//            entity.Property(e => e.VehicleVersionId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehicleVersionId");

//            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Models)
//                .HasForeignKey(d => d.ManufacturerId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("model_manufacturer_FK");

//            entity.HasOne(d => d.VehicleVersion).WithMany(p => p.Models)
//                .HasForeignKey(d => d.VehicleVersionId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("model_vehicleversion_FK");
//        });

//        modelBuilder.Entity<Operationalactivity>(entity =>
//        {
//            entity.HasKey(e => e.ActivityId).HasName("PRIMARY");

//            entity.ToTable("operationalactivities");

//            entity.HasIndex(e => e.CaretakeId, "operationalactivities_caretake_FK");

//            entity.HasIndex(e => e.ReservationId, "operationalactivities_reservations_FK");

//            entity.Property(e => e.ActivityId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("activityId");
//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.Cost).HasColumnName("cost");
//            entity.Property(e => e.Date).HasColumnName("date");
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .HasColumnName("name");
//            entity.Property(e => e.ReservationId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("reservationId");

//            entity.HasOne(d => d.Caretake).WithMany(p => p.Operationalactivities)
//                .HasForeignKey(d => d.CaretakeId)
//                .HasConstraintName("operationalactivities_caretake_FK");

//            entity.HasOne(d => d.Reservation).WithMany(p => p.Operationalactivities)
//                .HasForeignKey(d => d.ReservationId)
//                .HasConstraintName("operationalactivities_reservations_FK");
//        });

//        modelBuilder.Entity<Refuel>(entity =>
//        {
//            entity.HasKey(e => e.RefuelId).HasName("PRIMARY");

//            entity.ToTable("refuel");

//            entity.HasIndex(e => e.CaretakeId, "refuel_caretake_FK");

//            entity.HasIndex(e => e.ReservationId, "refuel_reservations_FK");

//            entity.Property(e => e.RefuelId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("refuelId");
//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.Cost).HasColumnName("cost");
//            entity.Property(e => e.CurrentMileage).HasColumnName("currentMileage");
//            entity.Property(e => e.Date).HasColumnName("date");
//            entity.Property(e => e.ReservationId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("reservationId");

//            entity.HasOne(d => d.Caretake).WithMany(p => p.Refuels)
//                .HasForeignKey(d => d.CaretakeId)
//                .HasConstraintName("refuel_caretake_FK");

//            entity.HasOne(d => d.Reservation).WithMany(p => p.Refuels)
//                .HasForeignKey(d => d.ReservationId)
//                .HasConstraintName("refuel_reservations_FK");
//        });

//        modelBuilder.Entity<Reservation>(entity =>
//        {
//            entity.HasKey(e => e.ReservationId).HasName("PRIMARY");

//            entity.ToTable("reservations");

//            entity.HasIndex(e => e.CaretakeId, "reservations_caretake_FK");

//            entity.HasIndex(e => e.EmployeeId, "reservations_employee_FK");

//            entity.HasIndex(e => e.VehicleId, "reservations_vehicle_FK");

//            entity.Property(e => e.ReservationId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("reservationId");
//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.FactualBeginDate).HasColumnName("factualBeginDate");
//            entity.Property(e => e.FactualEndDate).HasColumnName("factualEndDate");
//            entity.Property(e => e.PlannedBeginDate).HasColumnName("plannedBeginDate");
//            entity.Property(e => e.PlannedEndDate).HasColumnName("plannedEndDate");
//            entity.Property(e => e.PrivateUse).HasColumnName("privateUse");
//            entity.Property(e => e.Returned).HasColumnName("returned");
//            entity.Property(e => e.VehicleId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehicleId");
//            entity.Property(e => e.VehicleNoteAfterReservation)
//                .HasMaxLength(100)
//                .HasColumnName("vehicleNoteAfterReservation");
//            entity.Property(e => e.VehicleNoteBeforeReservation)
//                .HasMaxLength(100)
//                .HasColumnName("vehicleNoteBeforeReservation");

//            entity.HasOne(d => d.Caretake).WithMany(p => p.Reservations)
//                .HasForeignKey(d => d.CaretakeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("reservations_caretake_FK");
//        });

//        modelBuilder.Entity<Serviceoperation>(entity =>
//        {
//            entity.HasKey(e => e.ServiceOperationsId).HasName("PRIMARY");

//            entity.ToTable("serviceoperations");

//            entity.HasIndex(e => e.CaretakeId, "serviceoperations_caretake_FK");

//            entity.HasIndex(e => e.ReservationId, "serviceoperations_reservations_FK");

//            entity.Property(e => e.ServiceOperationsId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("serviceOperationsId");
//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.Cost).HasColumnName("cost");
//            entity.Property(e => e.Date).HasColumnName("date");
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .HasColumnName("name");
//            entity.Property(e => e.ReservationId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("reservationId");

//            entity.HasOne(d => d.Caretake).WithMany(p => p.Serviceoperations)
//                .HasForeignKey(d => d.CaretakeId)
//                .HasConstraintName("serviceoperations_caretake_FK");

//            entity.HasOne(d => d.Reservation).WithMany(p => p.Serviceoperations)
//                .HasForeignKey(d => d.ReservationId)
//                .HasConstraintName("serviceoperations_reservations_FK");
//        });

//        modelBuilder.Entity<Technicaloverview>(entity =>
//        {
//            entity.HasKey(e => e.OverviewId).HasName("PRIMARY");

//            entity.ToTable("technicaloverview");

//            entity.HasIndex(e => e.CaretakeId, "technicaloverview_caretake_FK");

//            entity.HasIndex(e => e.ReservationId, "technicaloverview_reservations_FK");

//            entity.Property(e => e.OverviewId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("overviewId");
//            entity.Property(e => e.CaretakeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("caretakeId");
//            entity.Property(e => e.Cost).HasColumnName("cost");
//            entity.Property(e => e.Date).HasColumnName("date");
//            entity.Property(e => e.NextOverviewDate).HasColumnName("nextOverviewDate");
//            entity.Property(e => e.Passed).HasColumnName("passed");
//            entity.Property(e => e.ReservationId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("reservationId");

//            entity.HasOne(d => d.Caretake).WithMany(p => p.Technicaloverviews)
//                .HasForeignKey(d => d.CaretakeId)
//                .HasConstraintName("technicaloverview_caretake_FK");

//            entity.HasOne(d => d.Reservation).WithMany(p => p.Technicaloverviews)
//                .HasForeignKey(d => d.ReservationId)
//                .HasConstraintName("technicaloverview_reservations_FK");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.UserId).HasName("PRIMARY");

//            entity.ToTable("user");

//            entity.HasIndex(e => e.EmployeeId, "user_employee_FK");

//            entity.Property(e => e.UserId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("userId");
//            entity.Property(e => e.EmployeeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("employeeId");
//            entity.Property(e => e.LastLogin).HasColumnName("lastLogin");
//            entity.Property(e => e.Password)
//                .HasMaxLength(500)
//                .HasColumnName("password");
//            entity.Property(e => e.Role)
//                .HasMaxLength(100)
//                .HasColumnName("role");
//            entity.Property(e => e.Username)
//                .HasMaxLength(100)
//                .HasColumnName("username");

//            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
//                .HasForeignKey(d => d.EmployeeId)
//                .HasConstraintName("user_employee_FK");
//        });

//        modelBuilder.Entity<Vehicle>(entity =>
//        {
//            entity.HasKey(e => e.VehicleId).HasName("PRIMARY");

//            entity.ToTable("vehicle");

//            entity.HasIndex(e => e.ModelId, "vehicle_model_FK");

//            entity.HasIndex(e => e.VehiclePurposeId, "vehicle_vehiclepurpose_FK_1");

//            entity.Property(e => e.VehicleId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehicleId");
//            entity.Property(e => e.IsInService).HasColumnName("isInService");
//            entity.Property(e => e.ModelId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("modelId");
//            entity.Property(e => e.PlateNumber)
//                .HasMaxLength(20)
//                .HasColumnName("plateNumber");
//            entity.Property(e => e.TotalMileage).HasColumnName("totalMileage");
//            entity.Property(e => e.VehiclePurposeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehiclePurposeId");
//            entity.Property(e => e.Vin)
//                .HasMaxLength(17)
//                .IsFixedLength()
//                .HasColumnName("VIN");

//            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
//                .HasForeignKey(d => d.ModelId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("vehicle_model_FK");

//            entity.HasOne(d => d.VehiclePurpose).WithMany(p => p.Vehicles)
//                .HasForeignKey(d => d.VehiclePurposeId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("vehicle_vehiclepurpose_FK_1");
//        });

//        modelBuilder.Entity<Vehicleoutfitting>(entity =>
//        {
//            entity.HasKey(e => e.OutfittingId).HasName("PRIMARY");

//            entity.ToTable("vehicleoutfitting");

//            entity.HasIndex(e => e.VersionId, "FK_vehicleoutfitting_vehicleversion");

//            entity.Property(e => e.OutfittingId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("outfittingId");
//            entity.Property(e => e.OutfittingName)
//                .HasMaxLength(100)
//                .HasColumnName("outfittingName");
//            entity.Property(e => e.VersionId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("versionId");

//            entity.HasOne(d => d.Version).WithMany(p => p.Vehicleoutfittings)
//                .HasForeignKey(d => d.VersionId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_vehicleoutfitting_vehicleversion");
//        });

//        modelBuilder.Entity<Vehiclepurpose>(entity =>
//        {
//            entity.HasKey(e => e.VehiclePurposeId).HasName("PRIMARY");

//            entity.ToTable("vehiclepurpose");

//            entity.Property(e => e.VehiclePurposeId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("vehiclePurposeId");
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .HasColumnName("name");
//        });

//        modelBuilder.Entity<Vehicleversion>(entity =>
//        {
//            entity.HasKey(e => e.VersionId).HasName("PRIMARY");

//            entity.ToTable("vehicleversion");

//            entity.Property(e => e.VersionId)
//                .HasColumnType("int(10) unsigned")
//                .HasColumnName("versionId");
//            entity.Property(e => e.Name)
//                .HasMaxLength(100)
//                .HasColumnName("name");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
