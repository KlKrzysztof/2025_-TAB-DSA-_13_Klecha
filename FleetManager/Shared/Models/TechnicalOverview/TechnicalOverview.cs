using System.ComponentModel.DataAnnotations;

namespace Shared.Models.TechnicalOverview;

public class TechnicalOverview
{
    [Key]
    public uint OverviewId { get; set; }

    public bool Passed { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly NextOverviewDate { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }
}