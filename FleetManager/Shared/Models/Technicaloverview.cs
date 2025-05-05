using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public partial class Technicaloverview
{
    [Key]
    public uint OverviewId { get; set; }

    public bool Passed { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly NextOverviewDate { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }

    public virtual Caretake Caretake { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}
