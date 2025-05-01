using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class User
{
    public uint UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly LastLogin { get; set; }

    public uint EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
