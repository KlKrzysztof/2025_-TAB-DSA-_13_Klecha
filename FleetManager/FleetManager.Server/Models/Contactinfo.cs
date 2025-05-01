using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Contactinfo
{
    public uint ContactId { get; set; }

    public uint EmployeeId { get; set; }

    public string TelNumber { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
