using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Refuel;

public class RefuelModel
{
    [Key]
    public uint RefuelId { get; set; }

    public double CurrentMileage { get; set; }

    public DateOnly Date { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }
}