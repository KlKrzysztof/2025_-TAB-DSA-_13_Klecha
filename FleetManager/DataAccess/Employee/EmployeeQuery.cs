using Shared.Contracts.Query;

namespace DataAccess.Employee;

public class EmployeeQuery : IEmployeeQuery
{
    public Task<FleetManager.Server.Models.Employee> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<FleetManager.Server.Models.Employee>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }
}