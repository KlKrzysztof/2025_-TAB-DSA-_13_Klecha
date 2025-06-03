using Shared.Models.Employee;

namespace Shared.Contracts.Query;

public interface IEmployeeQuery
{
    public Task<List<Employee>> GetEmployeesAsync();

    public Task<Employee?> GetEmployeeByIdAsync(int id);

    public Task CreateEmployee(Employee model);

    public Task CreateEmployeeWithContactInfo(EmployeeModel model, string contact1, string contact2);

    public Task UpdateEmployee(EmployeeModel model);

    public Task DeleteEmployee(int id);
}