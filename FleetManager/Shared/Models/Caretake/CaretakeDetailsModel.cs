using Shared.Models.Employee;
using Shared.Models.Vehicle;

namespace Shared.Models.Caretake;

public class CaretakeDetailsModel
{
    public int CaretakeId { get; set; }

    public CaretakeModel Caretake { get; set; } = new();

    public VehicleDetailsModel VehicleDetails { get; set; } = new();

    public EmployeeModel Caretaker { get; set; } = new();
}