using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Manufacturer
{
    public uint ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
