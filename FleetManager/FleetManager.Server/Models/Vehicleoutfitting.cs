using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Vehicleoutfitting
{
    public uint OutfittingId { get; set; }

    public uint VersionId { get; set; }

    public string? OutfittingName { get; set; }

    public virtual Vehicleversion Version { get; set; } = null!;
}
