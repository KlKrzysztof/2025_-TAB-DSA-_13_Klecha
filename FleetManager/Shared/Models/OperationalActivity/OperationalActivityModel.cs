using System.ComponentModel.DataAnnotations;

namespace Shared.Models.OperationalActivity;

public class OperationalActivityModel
{
    [Key]
    public uint ActivityId { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public DateOnly Date { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }
}
