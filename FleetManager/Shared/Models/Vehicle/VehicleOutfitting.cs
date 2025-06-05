using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Vehicle;

public class VehicleOutfitting
{
    [Key]
    public uint OutfittingId { get; set; }

    public uint VersionId { get; set; }

    public string? OutfittingName { get; set; }
}