using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Refuel;

namespace FleetManager.Server.DataAccess.Query;

public class RefuelQuery(VehicleContext db) : IRefuelQuery
{
    public async Task<List<RefuelModel>> GetRefuelsAsync()
    {
        return await db.Refuels.ToListAsync();
    }

    public async Task<RefuelModel?> GetRefuelByIdAsync(int id)
    {
        return await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == id);
    }

    public async Task<List<RefuelModel>?> GetRefuelsForVehicleAsync(int id)
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

    public async Task CreateRefuelAsync(RefuelModel model)
    {
        var r = await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == model.RefuelId);
        if (r == null)
        {
            await db.Refuels.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateRefuelAsync(RefuelModel model)
    {
        var r = await db.Refuels.AsNoTracking().SingleOrDefaultAsync(o => o.RefuelId == model.RefuelId);
        if (r != null)
        {
            db.Refuels.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteRefuelAsync(int id)
    {
        var r = await db.Refuels.SingleOrDefaultAsync(o => o.RefuelId == id);
        if (r != null)
        {
            db.Refuels.Remove(r);
            await db.SaveChangesAsync();
        }
    }
}
