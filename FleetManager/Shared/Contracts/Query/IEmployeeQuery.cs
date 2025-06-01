using Shared.Models;

namespace Shared.Contracts.Query;

public interface IEmployeeQuery
{
    public Task<List<EmployeeModel>> GetEmployeesAsync();

    public Task<EmployeeModel?> GetEmployeeByIdAsync(int id);

    public Task CreateEmployee(EmployeeModel model);

    public Task UpdateEmployee(EmployeeModel model);

    public Task DeleteEmployee(int id);
}