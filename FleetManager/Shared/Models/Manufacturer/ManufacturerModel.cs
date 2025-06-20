using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Manufacturer;

public class ManufacturerModel
{
    [Key]
    public uint ManufacturerId { get; set; }

    public string Name { get; set; } = null!;
}
