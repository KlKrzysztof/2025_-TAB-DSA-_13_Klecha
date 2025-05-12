using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Vehicleversion
{
    [Key]
    public uint VersionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<VehicleModel> Models { get; set; } = new List<VehicleModel>();

    public virtual ICollection<Vehicleoutfitting> Vehicleoutfittings { get; set; } = new List<Vehicleoutfitting>();
}
