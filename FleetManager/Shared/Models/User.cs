using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class User
{
    [Key]
    public uint UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateOnly LastLogin { get; set; }

    public uint EmployeeId { get; set; }

    public virtual EmployeeModel Employee { get; set; } = null!;
}
