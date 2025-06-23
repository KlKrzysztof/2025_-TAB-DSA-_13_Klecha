using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.ContactInfo;

namespace FleetManager.Server.DataAccess.Query;

public class ContactInfoQuery(EmployeeContext db) : IContactInfoQuery
{
    public async Task<List<ContactInfoModel>> GetContactInfosAsync()
    {
        return await db.ContactInfos.ToListAsync();
    }

    public async Task<ContactInfoModel?> GetContactInfoByIdAsync(int id)
    {
        return await db.ContactInfos.SingleOrDefaultAsync(opt => opt.ContactId == id);
    }

    public async Task<List<ContactInfoModel>?> GetEmployeesContactInfoAsync(int id)
    {
        return await db.ContactInfos.Where(opt => opt.EmployeeId == id).ToListAsync();
    }
   
    public async Task CreateContactInfoAsync(ContactInfoModel contactinfo)
    {
        var c = await db.ContactInfos.SingleOrDefaultAsync(opt => opt.ContactId == contactinfo.ContactId);
        if(c == null)
        {
            await db.ContactInfos.AddAsync(contactinfo);
            await db.SaveChangesAsync();
        }
    }
    public async Task UpdateContactInfoAsync(ContactInfoModel contactinfo)
    {
        var c = await db.ContactInfos.AsNoTracking().SingleOrDefaultAsync(opt => opt.ContactId == contactinfo.ContactId);
        if (c != null)
        {
            db.ContactInfos.Update(contactinfo);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteContactInfoAsync(int id)
    {
        var c = await db.ContactInfos.SingleOrDefaultAsync(opt => opt.ContactId == id);
        if (c != null)
        {
            db.ContactInfos.Remove(c);
            await db.SaveChangesAsync();
        }
    }
}