using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Vehicle;

public class VehiclePurpose
{
    [Key]
    public uint VehiclePurposeId { get; set; }

    public string? Name { get; set; }
}
