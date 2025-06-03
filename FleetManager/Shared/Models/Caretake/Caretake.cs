using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Caretake;

public class Caretake
{
    [Key]
    public uint CaretakeId { get; set; }

    public uint VehicleId { get; set; }

    public uint EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}