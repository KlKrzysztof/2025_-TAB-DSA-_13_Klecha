using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Model
{
    public uint ModelId { get; set; }

    public uint ManufacturerId { get; set; }

    public uint VehicleVersionId { get; set; }

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual Vehicleversion VehicleVersion { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
