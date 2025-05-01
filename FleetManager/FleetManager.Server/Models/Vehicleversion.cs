using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Vehicleversion
{
    public uint VersionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<Vehicleoutfitting> Vehicleoutfittings { get; set; } = new List<Vehicleoutfitting>();
}
