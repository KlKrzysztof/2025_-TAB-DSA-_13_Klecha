using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Caretake;

namespace FleetManager.Server.DataAccess.Query;

public class CaretakeQuery(VehicleContext db) : ICaretakeQuery
{
    public async Task<List<Caretake>> GetCaretakesAsync()
    {
        return await db.Caretakes.ToListAsync();
    }

    public async Task<Caretake?> GetCaretakeByEmployeeId(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.EmployeeId == id);
    }

    public async Task<Caretake?> GetCaretakeByIdAsync(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
    }

    public async Task<Caretake?> GetCaretakeByVehicleId(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
    }

    public async Task CreateCaretakeAsync(Caretake model)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if(c == null)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateCaretakeAsync(Caretake model)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if (c != null)
        {
            c = model;
            db.Update(c);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteCaretakeAsync(int id)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
        if (c != null)
        {
            db.Remove(c);
            await db.SaveChangesAsync();
        }
    }
}
