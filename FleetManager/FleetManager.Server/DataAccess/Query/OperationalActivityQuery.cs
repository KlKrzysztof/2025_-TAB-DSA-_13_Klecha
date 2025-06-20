using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.OperationalActivity;

namespace FleetManager.Server.DataAccess.Query;

public class OperationalActivityQuery(VehicleContext db) : IOperationalActivityQuery
{
    public async Task<List<OperationalActivityModel>> GetOperationalActivitiesAsync()
    {
        return await db.Operationalactivities.ToListAsync();
    }

    public async Task<List<OperationalActivityModel>?> GetOperationalActivitiesForVehicle(int id)
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

    public async Task<OperationalActivityModel?> GetOperationalActivityByIdAsync(int id)
    {
        return await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == id);
    }

    public async Task CreateOperationalActivityAsync(OperationalActivityModel model)
    {
        var o = await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == model.ActivityId);
        if (o == null)
        {
            await db.Operationalactivities.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateOperationalActivityAsync(OperationalActivityModel model)
    {
        var o = await db.Operationalactivities.AsNoTracking().SingleOrDefaultAsync(o => o.ActivityId == model.ActivityId);
        if (o != null)
        {
            db.Operationalactivities.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteOperationalActivityAsync(int id)
    {
        var o = await db.Operationalactivities.SingleOrDefaultAsync(o => o.ActivityId == id);
        if (o != null)
        {
            db.Operationalactivities.Remove(o);
            await db.SaveChangesAsync();
        }
    }
}