using Shared.Models.Employee;

namespace Shared.Models.Vehicle;

public class VehicleCaretakerModel
{
    public int VehicleId { get; set; }

    public EmployeeModel Caretaker { get; set; } = new();

    public Vehicle Vehicle { get; set; } = new();
}
