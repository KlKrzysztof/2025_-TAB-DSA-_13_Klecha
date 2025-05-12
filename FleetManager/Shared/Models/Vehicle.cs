using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Vehicle
{
    [Key]
    public uint VehicleId { get; set; }

    public double? TotalMileage { get; set; }

    public bool IsInService { get; set; }

    public uint VehiclePurposeId { get; set; }

    public string PlateNumber { get; set; } = null!;

    public uint ModelId { get; set; }

    public string Vin { get; set; } = null!;

    public virtual ICollection<Caretake> Caretakes { get; set; } = new List<Caretake>();

    public virtual VehicleModel Model { get; set; } = null!;

    public virtual Vehiclepurpose VehiclePurpose { get; set; } = null!;
}
