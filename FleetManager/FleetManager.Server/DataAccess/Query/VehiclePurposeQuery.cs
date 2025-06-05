using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.Query;

public class VehiclePurposeQuery(VehicleContext db) : IVehiclePurposeQuery
{
    public async Task<List<VehiclePurpose>> GetVehiclePurposesAsync()
    {
        return await db.VehiclePurposes.ToListAsync();
    }

    public async Task<VehiclePurpose?> GetVehiclePurposeByIdAsync(int id)
    {
        return await db.VehiclePurposes.SingleOrDefaultAsync(o => o.VehiclePurposeId == id);
    }

    public async Task<VehiclePurpose?> GetVehiclePurposeByNameAsync(string name)
    {
        return await db.VehiclePurposes.SingleOrDefaultAsync(o => o.Name == name);
    }

    public async Task CreateVehiclePurposeAsync(VehiclePurpose model)
    {
        var v = await db.VehiclePurposes.SingleOrDefaultAsync(opt => opt.VehiclePurposeId == model.VehiclePurposeId);
        if (v == null)
        {
            await db.VehiclePurposes.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehiclePurposeAsync(VehiclePurpose model)
    {
        var v = await db.VehiclePurposes.AsNoTracking().SingleOrDefaultAsync(opt => opt.VehiclePurposeId == model.VehiclePurposeId);
        if (v != null)
        {
            db.VehiclePurposes.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteVehiclePurposeAsync(int id)
    {
        var v = await db.VehiclePurposes.SingleOrDefaultAsync(opt => opt.VehiclePurposeId == id);
        if (v != null)
        {
            db.VehiclePurposes.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}
