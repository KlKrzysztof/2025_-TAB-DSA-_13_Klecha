using System.ComponentModel.DataAnnotations;

namespace Shared.Models.ServiceOperation;

public class ServiceOperationModel
{
    [Key]
    public uint ServiceOperationsId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Date { get; set; }

    public double Cost { get; set; }

    public uint CaretakeId { get; set; }

    public uint? ReservationId { get; set; }
}