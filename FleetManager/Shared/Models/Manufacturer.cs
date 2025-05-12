using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Manufacturer
{
    [Key]
    public uint ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<VehicleModel> Models { get; set; } = new List<VehicleModel>();
}
