using System;
using System.Collections.Generic;

namespace FleetManager.Server.Models;

public partial class Reservation
{
    public uint ReservationId { get; set; }

    public DateOnly FactualBeginDate { get; set; }

    public DateOnly FactualEndDate { get; set; }

    public uint EmployeeId { get; set; }

    public bool PrivateUse { get; set; }

    public uint? VehicleId { get; set; }

    public bool? Returned { get; set; }

    public DateOnly PlannedEndDate { get; set; }

    public DateOnly PlannedBeginDate { get; set; }

    public string? VehicleNoteBeforeReservation { get; set; }

    public string? VehicleNoteAfterReservation { get; set; }

    public uint CaretakeId { get; set; }

    public virtual Caretake Caretake { get; set; } = null!;

    public virtual ICollection<Operationalactivity> Operationalactivities { get; set; } = new List<Operationalactivity>();

    public virtual ICollection<Refuel> Refuels { get; set; } = new List<Refuel>();

    public virtual ICollection<Serviceoperation> Serviceoperations { get; set; } = new List<Serviceoperation>();

    public virtual ICollection<Technicaloverview> Technicaloverviews { get; set; } = new List<Technicaloverview>();
}
