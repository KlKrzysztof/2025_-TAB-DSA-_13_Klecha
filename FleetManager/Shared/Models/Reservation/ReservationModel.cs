using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Reservation;

public class ReservationModel
{
    [Key]
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
}