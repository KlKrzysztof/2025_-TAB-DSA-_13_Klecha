using Shared.Models;

namespace Shared.Contracts.Query;

public interface IEmployeeQuery
{
    public Task<List<EmployeeModel>> GetEmployeesAsync();

    public Task<EmployeeModel?> GetEmployeeByIdAsync(int id);
}