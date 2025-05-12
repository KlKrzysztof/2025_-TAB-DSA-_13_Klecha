using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleOutfittingQuery(VehicleContext db) : IVehicleOutfittingQuery
{
    public async Task<List<Vehicleoutfitting>> GetVehicleoutfittingsAsync()
    {
        return await db.VehicleOutfittings.ToListAsync();
    }

    public async Task<Vehicleoutfitting?> GetVehicleoutfittingByIdAsync(int id)
    {
        return await db.VehicleOutfittings.SingleOrDefaultAsync(o => o.OutfittingId == id);
    }

    public async Task CreateVehicleOutfittingAsync(Vehicleoutfitting model)
    {
        var v = await db.VehicleOutfittings.SingleOrDefaultAsync(opt => opt.OutfittingId == model.OutfittingId);
        if (v == null)
        {
            await db.VehicleOutfittings.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehicleOutfittingAsync(Vehicleoutfitting model)
    {
        var v = await db.VehicleOutfittings.SingleOrDefaultAsync(opt => opt.OutfittingId == model.OutfittingId);
        if (v != null)
        {
            v = model;
            db.VehicleOutfittings.Update(v);
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
