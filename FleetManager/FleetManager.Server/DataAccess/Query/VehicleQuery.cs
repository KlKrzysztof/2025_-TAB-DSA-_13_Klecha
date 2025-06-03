using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleQuery(VehicleContext db) : IVehicleQuery
{
    public async Task<List<Vehicle>> GetVehiclesAsync()
    {
        return await db.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleByIdAsync(int id)
    {
        return await db.Vehicles.SingleOrDefaultAsync(opt => opt.VehicleId == id);
    }

    public async Task<Vehicle?> GetVehicleByPlateNumber(string plateNumber)
    {
        return await db.Vehicles.SingleOrDefaultAsync(opt => opt.PlateNumber == plateNumber);
    }

    public async Task<Vehicle?> GetVehicleByVinAsync(string vin)
    {
        return await db.Vehicles.SingleOrDefaultAsync(opt => opt.Vin == vin);
    }

    public async Task CreateVehicleAsync(Vehicle model)
    {
        var v = await db.Vehicles.SingleOrDefaultAsync(opt => opt.VehicleId == model.VehicleId);
        if (v == null)
        {
            await db.Vehicles.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehicleAsync(Vehicle model)
    {
        var v = await db.Vehicles.SingleOrDefaultAsync(opt => opt.VehicleId == model.VehicleId);
        if (v != null)
        {
            v = model;
            db.Vehicles.Update(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var v = await db.Vehicles.SingleOrDefaultAsync(opt => opt.VehicleId == id);
        if (v != null)
        {
            db.Vehicles.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}