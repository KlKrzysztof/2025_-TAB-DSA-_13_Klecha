using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Manufacturer;

namespace FleetManager.Server.DataAccess.Query;

public class ManufacturerQuery(VehicleContext db) : IManufacturerQuery
{
    public async Task<List<ManufacturerModel>> GetManufacturersAsync()
    {
        return await db.Manufacturers.ToListAsync();
    }

    public async Task<ManufacturerModel?> GetManufacturerByIdAsync(int id)
    {
        return await db.Manufacturers.SingleOrDefaultAsync(o => o.ManufacturerId == id);
    }

    public async Task<ManufacturerModel?> GetManufacturerByNameAsync(string name)
    {
        return await db.Manufacturers.SingleOrDefaultAsync(o => o.Name == name);
    }

    public async Task CreateManufacturerAsync(ManufacturerModel manufacturer)
    {
        var v = await db.Manufacturers.SingleOrDefaultAsync(opt => opt.ManufacturerId == manufacturer.ManufacturerId);
        if (v == null)
        {
            await db.Manufacturers.AddAsync(manufacturer);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateManufacturerAsync(ManufacturerModel manufacturer)
    {
        var v = await db.Manufacturers.AsNoTracking().SingleOrDefaultAsync(opt => opt.ManufacturerId == manufacturer.ManufacturerId);
        if (v != null)
        {
            db.Manufacturers.Update(manufacturer);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteManufacturerAsync(int id)
    {
        var v = await db.Manufacturers.SingleOrDefaultAsync(opt => opt.ManufacturerId == id);
        if (v != null)
        {
            db.Manufacturers.Remove(v);
            await db.SaveChangesAsync();
        }
    }
}