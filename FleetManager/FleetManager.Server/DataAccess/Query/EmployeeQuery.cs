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
}