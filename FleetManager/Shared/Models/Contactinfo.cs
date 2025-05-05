using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Contactinfo
{
    [Key]
    public uint ContactId { get; set; }

    public uint EmployeeId { get; set; }

    public string TelNumber { get; set; } = null!;

    public virtual EmployeeModel Employee { get; set; } = null!;
}
