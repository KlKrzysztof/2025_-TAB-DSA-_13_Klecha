using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.Address;
using System.Net;

namespace FleetManager.Server.DataAccess.Query;

public class AddressQuery(EmployeeContext db) : IAddressQuery
{
    public async Task<List<Address>> GetAddressesAsync()
    {
        return await db.Addresses.ToListAsync();
    }

    public async Task<Address?> GetAddressByIdAsync(int id)
    {
        return await db.Addresses.SingleOrDefaultAsync(o => o.AddressId == id);
    }

    public async Task<List<Address>?> GetAddressesByEmployeeIdAsync(int id)
    {
        return await db.Addresses.Where(o => o.EmployeeId == id).ToListAsync();
    }

    public async Task CreateAddressAsync(Address address)
    {
        var e = await db.Addresses.SingleOrDefaultAsync(opt => opt.AddressId == address.AddressId);
        if (e == null)
        {
            await db.Addresses.AddAsync(address);
            await db.SaveChangesAsync();
        }
    }

    public async Task UpdateAddressAsync(Address address)
    {
        var e = await db.Addresses.SingleOrDefaultAsync(opt => opt.AddressId == address.AddressId);
        if (e != null)
        {
            e = address;
            db.Addresses.Update(e);
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
