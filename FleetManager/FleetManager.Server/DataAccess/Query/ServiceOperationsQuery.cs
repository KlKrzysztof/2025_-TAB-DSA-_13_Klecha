using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.ServiceOperation;

namespace FleetManager.Server.DataAccess.Query;

public class ServiceOperationsQuery(VehicleContext db) : IServiceOperationsQuery
{
    public async Task<List<ServiceOperationModel>> GetServiceOperationsAsync()
    {
        return await db.Serviceoperations.ToListAsync();
    }

    public async Task<ServiceOperationModel?> GetServiceOperationByIdAsync(int id)
    {
        return await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == id);
    }

    public async Task<List<ServiceOperationModel>?> GetServiceOperationsForVehicleAsync(int id)
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

    public async Task CreateServiceOperationAsync(ServiceOperationModel model)
    {
        var s = await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == model.ServiceOperationsId);
        if (s == null)
        {
            await db.Serviceoperations.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateServiceOperationAsync(ServiceOperationModel model)
    {
        var s = await db.Serviceoperations.AsNoTracking().SingleOrDefaultAsync(o => o.ServiceOperationsId == model.ServiceOperationsId);
        if (s != null)
        {
            db.Serviceoperations.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteServiceOperationsAsync(int id)
    {
        var s = await db.Serviceoperations.SingleOrDefaultAsync(o => o.ServiceOperationsId == id);
        if (s != null)
        {
            db.Serviceoperations.Remove(s);
            await db.SaveChangesAsync();
        }
    }
}