using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Caretake;

namespace FleetManager.Server.DataAccess.Query;

public class CaretakeQuery(VehicleContext db) : ICaretakeQuery
{
    public async Task<List<CaretakeModel>> GetCaretakesAsync()
    {
        return await db.Caretakes.ToListAsync();
    }

    public async Task<CaretakeModel?> GetCaretakeByEmployeeId(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.EmployeeId == id);
    }

    public async Task<CaretakeModel?> GetCaretakeByIdAsync(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == id);
    }

    public async Task<CaretakeModel?> GetCaretakeByVehicleId(int id)
    {
        return await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
    }

    public async Task CreateCaretakeAsync(CaretakeModel model)
    {
        var c = await db.Caretakes.SingleOrDefaultAsync(o => o.CaretakeId == model.CaretakeId);
        if(c == null)
        {
            await db.Caretakes.AddAsync(model);
            await db.SaveChangesAsync();
        }
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
