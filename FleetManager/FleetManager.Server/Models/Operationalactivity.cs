using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Operationalactivity
{
    public uint ActivityId { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public DateOnly Date { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }

    public virtual Caretake Caretake { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}
