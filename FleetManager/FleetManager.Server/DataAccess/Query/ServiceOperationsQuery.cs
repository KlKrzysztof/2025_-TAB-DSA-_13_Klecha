using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class ServiceOperationsQuery(VehicleContext db) : IServiceOperationsQuery
{
    public async Task<List<Serviceoperation>> GetServiceOperationsAsync()
    {
        return await db.Serviceoperations.ToListAsync();
    }

    public async Task<Serviceoperation?> GetServiceOperationByIdAsync(int id)
    {
        return await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == id);
    }

    public async Task<List<Serviceoperation>?> GetServiceOperationsForVehicleAsync(int id)
    {
        var caretake = await db.Caretakes.SingleOrDefaultAsync(o => o.VehicleId == id);
        if (caretake == null)
        {
            return [];
        }
        else
        {
            return await db.Serviceoperations.Where(o => o.CaretakeId == caretake.CaretakeId).ToListAsync();
        }
    }

    public async Task CreateServiceOperationAsync(Serviceoperation model)
    {
        var s = await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == model.ServiceOperationsId);
        if (s == null)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateServiceOperationAsync(Serviceoperation model)
    {
        var s = await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == model.ServiceOperationsId);
        if (s != null)
        {
            s = model;
            db.Update(s);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteServiceOperationsAsync(int id)
    {
        var s = await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == id);
        if (s != null)
        {
            db.Remove(s);
            await db.SaveChangesAsync();
        }
    }
}