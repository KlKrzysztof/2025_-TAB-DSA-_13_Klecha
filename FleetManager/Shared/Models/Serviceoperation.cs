using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Serviceoperation
{
    [Key]
    public uint ServiceOperationsId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Date { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }

    public virtual Caretake Caretake { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}
