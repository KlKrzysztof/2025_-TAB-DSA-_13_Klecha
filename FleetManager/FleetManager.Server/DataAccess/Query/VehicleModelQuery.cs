using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleModelQuery(VehicleContext db) : IVehicleModelQuery
{
    public async Task<List<VehicleModel>> GetVehicleModelsAsync()
    {
        return await db.VehicleModels.ToListAsync();
    }

    public async Task<VehicleModel?> GetVehicleModelByIdAsync(int id)
    {
        return await db.VehicleModels.SingleOrDefaultAsync(o => o.ModelId == id);
    }

    public async Task CreateVehicleModelAsync(VehicleModel model)
    {
        var v = await db.VehicleModels.SingleOrDefaultAsync(opt => opt.ModelId == model.ModelId);
        if (v == null)
        {
            await db.VehicleModels.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehicleModelAsync(VehicleModel model)
    {
        var v = await db.VehicleModels.AsNoTracking().SingleOrDefaultAsync(opt => opt.ModelId == model.ModelId);
        if (v != null)
        {
            db.VehicleModels.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteVehicleModelAsync(int id)
    {
        var v = await db.VehicleModels.SingleOrDefaultAsync(o => o.ModelId == id);
        if (v != null)
        {
            db.VehicleModels.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}