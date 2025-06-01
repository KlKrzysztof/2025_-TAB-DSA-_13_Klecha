using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class EmployeeQuery(EmployeeContext db) : IEmployeeQuery
{
    public async Task<List<EmployeeModel>> GetEmployeesAsync()
    {
        return await db.Employees.ToListAsync();
    }

    public async Task<EmployeeModel?> GetEmployeeByIdAsync(int id)
    {
        return await db.Employees.SingleOrDefaultAsync<EmployeeModel>(opt => opt.EmployeeId == id);
    }

    public async Task CreateEmployee(EmployeeModel model)
    {
        var emp = await db.Employees.SingleOrDefaultAsync(o => o.EmployeeId == model.EmployeeId);
        if (emp == null)
        {
            await db.Employees.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateEmployee(EmployeeModel model)
    {
        var emp = await db.Employees.SingleOrDefaultAsync(o => o.EmployeeId == model.EmployeeId);
        if (emp != null)
        {
            emp = model;
            db.Employees.Update(emp);
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