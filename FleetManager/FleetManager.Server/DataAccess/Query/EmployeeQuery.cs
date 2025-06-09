using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Employee;

namespace FleetManager.Server.DataAccess.Query;

public class EmployeeQuery(EmployeeContext db) : IEmployeeQuery
{
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await db.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await db.Employees.SingleOrDefaultAsync<Employee>(opt => opt.EmployeeId == id);
    }

    public async Task CreateEmployee(Employee model)
    {
        var emp = await db.Employees.SingleOrDefaultAsync(o => o.EmployeeId == model.EmployeeId);
        if (emp == null)
        {
            await db.Employees.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateEmployee(Employee model)
    {
        var emp = await db.Employees.AsNoTracking().SingleOrDefaultAsync(o => o.EmployeeId == model.EmployeeId);
        if (emp != null)
        {
            db.Employees.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteEmployee(int id)
    {
        var emp = await db.Employees.SingleOrDefaultAsync(o => o.EmployeeId == id);
        if (emp != null)
        {
            db.Employees.Remove(emp);
            await db.SaveChangesAsync();
        }
    }
}