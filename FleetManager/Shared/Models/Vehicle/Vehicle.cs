using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Vehicle;

public class Vehicle
{
    [Key]
    public uint VehicleId { get; set; }

    public double? TotalMileage { get; set; }

    public bool IsInService { get; set; }

    public uint VehiclePurposeId { get; set; }

    public string PlateNumber { get; set; } = null!;

    public uint ModelId { get; set; }

    public string Vin { get; set; } = null!;
}