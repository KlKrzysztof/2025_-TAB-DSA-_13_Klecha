using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Vehicleoutfitting
{
    [Key]
    public uint OutfittingId { get; set; }

    public uint VersionId { get; set; }

    public string? OutfittingName { get; set; }

    public virtual Vehicleversion Version { get; set; } = null!;
}
