using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleOutfittingQuery(VehicleContext db) : IVehicleOutfittingQuery
{
    public async Task<List<VehicleOutfitting>> GetVehicleoutfittingsAsync()
    {
        return await db.VehicleOutfittings.ToListAsync();
    }

    public async Task<VehicleOutfitting?> GetVehicleoutfittingByIdAsync(int id)
    {
        return await db.VehicleOutfittings.SingleOrDefaultAsync(o => o.OutfittingId == id);
    }

    public async Task CreateVehicleOutfittingAsync(VehicleOutfitting model)
    {
        var v = await db.VehicleOutfittings.SingleOrDefaultAsync(opt => opt.OutfittingId == model.OutfittingId);
        if (v == null)
        {
            await db.VehicleOutfittings.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehicleOutfittingAsync(VehicleOutfitting model)
    {
        var v = await db.VehicleOutfittings.AsNoTracking().SingleOrDefaultAsync(opt => opt.OutfittingId == model.OutfittingId);
        if (v != null)
        {
            db.VehicleOutfittings.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteVehicleOutfittingAsync(int id)
    {
        var v = await db.VehicleOutfittings.SingleOrDefaultAsync(opt => opt.OutfittingId == id);
        if (v != null)
        {
            db.VehicleOutfittings.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}
