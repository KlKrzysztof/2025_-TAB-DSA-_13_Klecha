using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class OperationalActivityQuery(VehicleContext db) : IOperationalActivityQuery
{
    public async Task<List<Operationalactivity>> GetOperationalActivitiesAsync()
    {
        return await db.Operationalactivities.ToListAsync();
    }

    public async Task<List<Operationalactivity>?> GetOperationalActivitiesForVehicle(int id)
    {
        var caretake = await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
        if (caretake == null)
        {
            return [];
        }
        else
        {
            return await db.Operationalactivities.Where(o => o.CaretakeId == caretake.CaretakeId).ToListAsync();
        }
    }

    public async Task<Operationalactivity?> GetOperationalActivityByIdAsync(int id)
    {
        return await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == id);
    }

    public async Task CreateOperationalActivityAsync(Operationalactivity model)
    {
        var o = await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == model.ActivityId);
        if (o == null)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateOperationalActivityAsync(Operationalactivity model)
    {
        var o = await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == model.ActivityId);
        if (o != null)
        {
            o = model;
            db.Update(o);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteOperationalActivityAsync(int id)
    {
        var o = await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == id);
        if (o != null)
        {
            db.Remove(o);
            await db.SaveChangesAsync();
        }
    }
}