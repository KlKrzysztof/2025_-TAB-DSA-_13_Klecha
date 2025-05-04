using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Vehiclepurpose
{
    [Key]
    public uint VehiclePurposeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
