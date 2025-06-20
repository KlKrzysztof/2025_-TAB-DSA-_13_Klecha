using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.User;

namespace FleetManager.Server.DataAccess.Query;

public class UserQuery(EmployeeContext db) : IUserQuery
{

    public async Task<List<UserModel>> GetUsersAsync()
    {
        return await db.UsersInfo.ToListAsync();
    }

    public async Task<UserModel?> GetUserByEmployeeIdAsync(int id)
    {
        return await db.UsersInfo.SingleOrDefaultAsync(o => o.EmployeeId == id);
    }

    public async Task<UserModel?> GetUserByIdAsync(int id)
    {
        return await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == id);
    }

    public async Task CreateUserAsync(UserModel user)
    {
        var u = await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == user.UserId);
        if (u == null)
        {
            await db.UsersInfo.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
    public async Task UpdateUserAsync(UserModel user)
    {
        var u = await db.UsersInfo.AsNoTracking().SingleOrDefaultAsync(o => o.UserId == user.UserId);
        if (u != null)
        {
            db.UsersInfo.Update(user);
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteUserAsync(int id)
    {
        var u = await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == id);
        if (u != null)
        {
            db.UsersInfo.Remove(u);
            await db.SaveChangesAsync();
        }
    }
}
