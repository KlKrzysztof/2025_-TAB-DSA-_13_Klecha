using System.ComponentModel.DataAnnotations;

namespace Shared.Models.Caretake;

public class CaretakeModel
{
    public CaretakeModel()
    {
    }

    public CaretakeModel(CaretakeModel other)
    {
        CaretakeId = other.CaretakeId;
        VehicleId = other.VehicleId;
        EmployeeId = other.EmployeeId;
        StartDate = other.StartDate;
        EndDate = other.EndDate;
    }

    [Key]
    public uint CaretakeId { get; set; }

    public uint VehicleId { get; set; }

    public uint EmployeeId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}