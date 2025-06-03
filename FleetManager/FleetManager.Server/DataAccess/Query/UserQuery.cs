using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Query;
using Shared.Models.User;

namespace FleetManager.Server.DataAccess.Query;

public class UserQuery(EmployeeContext db) : IUserQuery
{

    public async Task<List<User>> GetUsersAsync()
    {
        return await db.UsersInfo.ToListAsync();
    }

    public async Task<User?> GetUserByEmployeeIdAsync(int id)
    {
        return await db.UsersInfo.SingleOrDefaultAsync(o => o.EmployeeId == id);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == id);
    }

    public async Task CreateUserAsync(User user)
    {
        var u = await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == user.UserId);
        if (u == null)
        {
            await db.UsersInfo.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
    public async Task UpdateUserAsync(User user)
    {
        var u = await db.UsersInfo.SingleOrDefaultAsync(o => o.UserId == user.UserId);
        if (u != null)
        {
            u = user;
            db.UsersInfo.Update(u);
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
