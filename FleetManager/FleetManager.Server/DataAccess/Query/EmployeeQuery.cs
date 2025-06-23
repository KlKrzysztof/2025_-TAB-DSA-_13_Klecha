using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.ContactInfo;
using Shared.Models.Employee;

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
        }\

    }

    public async Task CreateEmployeeWithContactInfo(EmployeeModel model, string contact1, string contact2)
    {
        var emp = await db.Employees.SingleOrDefaultAsync(o => o.EmployeeId == model.EmployeeId);
        if (emp == null)
        {
            await db.Employees.AddAsync(model);
            await db.SaveChangesAsync();
            ContactInfoModel c1 = new() { EmployeeId = model.EmployeeId, TelNumber = contact1};
            ContactInfoModel c2 = new() { EmployeeId = model.EmployeeId, TelNumber = contact2};
            await db.ContactInfos.AddAsync(c1);
            await db.ContactInfos.AddAsync(c2);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateEmployee(EmployeeModel model)
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
            var contactInfos = await db.ContactInfos.Where(c => c.EmployeeId == id).ToListAsync();

            foreach(var contact in contactInfos)
            {
                try
                {
                    db.ContactInfos.Remove(contact);
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
            await db.SaveChangesAsync();

            db.Employees.Remove(emp);
            await db.SaveChangesAsync();
        }
    }
}