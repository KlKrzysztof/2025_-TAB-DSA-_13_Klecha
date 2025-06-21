using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Vehicle;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleQuery(VehicleContext db) : IVehicleQuery
{

    //piotrek service begin
    public async Task<List<Vehicle>> GetVehiclesInServiceAsync()
    {
        return await db.Vehicles
            .Where(v => v.IsInService)
            .ToListAsync();
    }
    public async Task<List<Vehicle>> GetVehiclesNotInServiceAsync()
    {
        return await db.Vehicles
            .Where(v => !(v.IsInService))
            .ToListAsync();
    }
    public async Task UpdateSendToService(int id)
    {
        Vehicle vehicleToSend = await GetVehicleByIdAsync(id);
        vehicleToSend.IsInService = true;
        await UpdateVehicleAsync(vehicleToSend);
    }
    public async Task UpdateReturnFromService(int id)
    {
        Vehicle vehicleToSend = await GetVehicleByIdAsync(id);
        vehicleToSend.IsInService = false;
        await UpdateVehicleAsync(vehicleToSend);
    }
    //piotrek service end
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

    public async Task<VehicleDetailsModel?> GetVehicleDetailsByIdAsync(int id)
    {
        var vehicle = await GetVehicleByIdAsync(id);
        if (vehicle == null) { return null; }

        var model = await db.VehicleModels.SingleOrDefaultAsync(o => o.ModelId == vehicle.ModelId);
        if (model == null) { return null; }

        var manufacturer = await db.Manufacturers.SingleOrDefaultAsync(o => o.ManufacturerId == model.ManufacturerId);
        if (manufacturer == null) { return null; }

        var version = await db.VehicleVersions.SingleOrDefaultAsync(o => o.VersionId == model.VehicleVersionId);
        if (version == null) { return null; }

        var outfitting = await db.VehicleOutfittings.Where(o => o.VersionId == version.VersionId).ToListAsync();
        if (outfitting == null) { return null; }

        VehicleDetailsModel m = new()
        {
            VehicleId = id,
            Vehicle = vehicle,
            VehicleModel = model,
            VehicleManufacturer = manufacturer,
            VehicleOutfitting = outfitting,
            VehiclePurpose = await db.VehiclePurposes.SingleOrDefaultAsync(o => o.VehiclePurposeId == vehicle.VehiclePurposeId),
            VehicleVersion = version
        };

        return m ?? null;
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
        var v = await db.Vehicles.AsNoTracking().SingleOrDefaultAsync(opt => opt.VehicleId == model.VehicleId);
        if (v != null)
        {
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