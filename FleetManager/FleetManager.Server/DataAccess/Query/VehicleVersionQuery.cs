﻿using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models;

namespace FleetManager.Server.DataAccess.Query;

public class VehicleVersionQuery(VehicleContext db) : IVehicleVersionQuery
{
    public async Task<List<Vehicleversion>> GetVehicleVersionsAsync()
    {
        return await db.VehicleVersions.ToListAsync();
    }

    public async Task<Vehicleversion?> GetVehicleVersionByIdAsync(int id)
    {
        return await db.VehicleVersions.SingleOrDefaultAsync(opt => opt.VersionId == id);
    }

    public async Task CreateVehicleVersionAsync(Vehicleversion model)
    {
        var v = await db.VehicleVersions.SingleOrDefaultAsync(opt => opt.VersionId == model.VersionId);
        if (v == null)
        {
            await db.VehicleVersions.AddAsync(model);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateVehicleVersionAsync(Vehicleversion model)
    {
        var v = await db.VehicleVersions.SingleOrDefaultAsync(opt => opt.VersionId == model.VersionId);
        if (v != null)
        {
            v = model;
            db.VehicleVersions.Update(v);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteVehicleVersionAsync(int id)
    {
        var v = await db.VehicleVersions.SingleOrDefaultAsync(opt => opt.VersionId == id);
        if (v != null)
        {
            db.VehicleVersions.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}