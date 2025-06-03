using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Vehicle;

public class VehicleVersion
{
    [Key]
    public uint VersionId { get; set; }

    public string? Name { get; set; }
}
