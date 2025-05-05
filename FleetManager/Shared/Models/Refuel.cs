using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Refuel
{
    [Key]
    public uint RefuelId { get; set; }

    public double CurrentMileage { get; set; }

    public DateOnly Date { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }

    public virtual Caretake Caretake { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}
