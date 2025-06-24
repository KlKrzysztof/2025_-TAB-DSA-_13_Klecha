using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Caretake;

namespace FleetManager.Server.DataAccess.Query;

public class CaretakeQuery(VehicleContext db, EmployeeContext employeeDb) : ICaretakeQuery
{
    public async Task<List<CaretakeModel>> GetCaretakesAsync()
    {
        return await db.Caretakes.ToListAsync();
    }

    public async Task<List<CaretakeModel>> GetCaretakeByEmployeeIdAsync(int id)
    {
        return await db.Caretakes.Where(o => o.EmployeeId == id && o.EndDate == null).ToListAsync();
    }

    public async Task<CaretakeModel?> GetCaretakeByIdAsync(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
    }

    public async Task<CaretakeModel?> GetCaretakeByVehicleIdAsync(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id && o.EndDate == null);
    }

    public async Task<CaretakeDetailsModel?> GetCaretakeDetailsByIdAsync(int id)
    {
        var caretake = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
        if (caretake == null) { return null; }

        var caretaker = await employeeDb.Employees.SingleOrDefaultAsync(o => o.EmployeeId == caretake.EmployeeId);
        if (caretaker == null) { return null; }

        CaretakeDetailsModel model = new()
        {
            CaretakeId = id,
            Caretake = caretake,
            Caretaker = caretaker
        };

        return model;
    }

    public async Task<List<CaretakeModel>> GetFinishedCaretakesAsync()
    {
        DateOnly currentDate = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        return await db.Caretakes.Where(o => o.EndDate <= currentDate).ToListAsync();
    }

    public async Task CreateCaretakeAsync(CaretakeModel model)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if (c == null)
        {
            await db.Caretakes.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task PatchVehicleCaretakerAsync(uint employeeId, int vehicleId)
    {
        DateOnly currentDate = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        var currentCaretake = await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == vehicleId);
        //if (currentCaretake == null) { return; }
        CaretakeModel newCaretake = new();
        if (currentCaretake != null)
        {
            newCaretake = new(currentCaretake);
        }
        else
        {
            newCaretake.VehicleId = (uint) vehicleId;
        }
        newCaretake.CaretakeId = 0;
        newCaretake.StartDate = currentDate;
        newCaretake.EndDate = null;
        newCaretake.EmployeeId = employeeId;

        if (currentCaretake != null)
        {
            currentCaretake.EndDate = currentDate;
            db.Caretakes.Update(currentCaretake);
        }
        await db.AddAsync(newCaretake);
        await db.SaveChangesAsync();
    }

    public async Task UpdateCaretakeAsync(CaretakeModel model)
    {
        var c = await db.Caretakes.AsNoTracking().SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if (c != null)
        {
            db.Caretakes.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteCaretakeAsync(int id)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
        if (c != null)
        {
            db.Caretakes.Remove(c);
            await db.SaveChangesAsync();
        }
    }
}