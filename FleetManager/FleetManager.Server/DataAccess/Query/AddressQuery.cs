﻿using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Address;
using System.Net;

namespace FleetManager.Server.DataAccess.Query;

public class AddressQuery(EmployeeContext db) : IAddressQuery
{
    public async Task<List<AddressModel>> GetAddressesAsync()
    {
        return await db.Addresses.ToListAsync();
    }

    public async Task<AddressModel?> GetAddressByIdAsync(int id)
    {
        return await db.Addresses.SingleOrDefaultAsync(o => o.AddressId == id);
    }

    public async Task<List<AddressModel>?> GetAddressesByEmployeeIdAsync(int id)
    {
        return await db.Addresses.Where(o => o.EmployeeId == id).ToListAsync();
    }

    public async Task CreateAddressAsync(AddressModel address)
    {
        var e = await db.Addresses.SingleOrDefaultAsync(opt => opt.AddressId == address.AddressId);
        if (e == null)
        {
            await db.Addresses.AddAsync(address);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateAddressAsync(AddressModel address)
    {
        var e = await db.Addresses.AsNoTracking().SingleOrDefaultAsync(opt => opt.AddressId == address.AddressId);
        if (e != null)
        {
            db.Addresses.Update(address);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteAddressAsync(int id)
    {
        var e = await db.Addresses.SingleOrDefaultAsync(opt => opt.AddressId == id);
        if (e != null)
        {
            db.Addresses.Remove(e);
            await db.SaveChangesAsync();
        }
    }
}
