using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class RefuelQuery(VehicleContext db) : IRefuelQuery
{
    public async Task<List<Refuel>> GetRefuelsAsync()
    {
        return await db.Refuels.ToListAsync();
    }

    public async Task<Refuel?> GetRefuelByIdAsync(int id)
    {
        return await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == id);
    }

    public async Task<List<Refuel>?> GetRefuelsForVehicleAsync(int id)
    {
        var caretake = await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
        if(caretake == null)
        {
            return [];
        }
        else
        {
            return await db.Refuels.Where(o => o.CaretakeId == caretake.CaretakeId).ToListAsync();
        }
    }

    public async Task CreateRefuelAsync(Refuel model)
    {
        var r = await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == model.RefuelId);
        if (r == null)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateRefuelAsync(Refuel model)
    {
        var r = await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == model.RefuelId);
        if (r != null)
        {
            r = model;
            db.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteRefuelAsync(int id)
    {
        var r = await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == id);
        if (r != null)
        {
            db.Update(r);
            await db.SaveChangesAsync();
        }
    }
}
