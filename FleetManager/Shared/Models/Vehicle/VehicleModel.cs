using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Vehicle;

public class VehicleModel
{
    [Key]
    public uint ModelId { get; set; }

    public uint ManufacturerId { get; set; }

    public uint VehicleVersionId { get; set; }
}