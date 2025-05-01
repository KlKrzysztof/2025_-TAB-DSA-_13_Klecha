using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Vehiclepurpose
{
    public uint VehiclePurposeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
