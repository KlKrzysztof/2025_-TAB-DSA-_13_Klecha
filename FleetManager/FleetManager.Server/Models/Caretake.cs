using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Caretake
{
    public uint CaretakeId { get; set; }

    public uint VehicleId { get; set; }

    public uint EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Operationalactivity> Operationalactivities { get; set; } = new List<Operationalactivity>();

    public virtual ICollection<Refuel> Refuels { get; set; } = new List<Refuel>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Serviceoperation> Serviceoperations { get; set; } = new List<Serviceoperation>();

    public virtual ICollection<Technicaloverview> Technicaloverviews { get; set; } = new List<Technicaloverview>();

    public virtual Vehicle Vehicle { get; set; } = null!;
}
