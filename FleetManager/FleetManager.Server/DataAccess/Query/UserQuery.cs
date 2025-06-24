using FleetManager.Server.DataAccess.DbContexts;
using Microsoft.AspNetCore.Identity;
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
            var loginCheck = await GetUserByLoginAsync(user.Username);
            if (loginCheck != null)
            {
                await Task.CompletedTask;
            }
            else
            {
                PasswordHasher<string> hasher = new();
                user.Password = hasher.HashPassword(user.Username, user.Password);
                await db.UsersInfo.AddAsync(user);
                await db.SaveChangesAsync();
            }
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

    public async Task<bool> Authenticate(string login, string password)
    {
        PasswordHasher<string> hasher = new();

        var users = await GetUsersAsync();
        if (users == null || users.Count == 0)
        {
            return await Task.FromResult(false);
        }

        foreach (var user in users)
        {
            if (login == user.Username)
            {
                var res = hasher.VerifyHashedPassword(login, user.Password, password);
                if (res == PasswordVerificationResult.Success)
                {
                    return await Task.FromResult(true);
                }
            }
        }

        return await Task.FromResult(false);
    }

    public async Task<UserModel?> GetUserByLoginAsync(string login)
    {
        return await db.UsersInfo.SingleOrDefaultAsync(o => o.Username == login);
    }

    public async Task PatchLastLogin(int id)
    {
        var date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        await db.UsersInfo.Where(o => o.UserId == id).ExecuteUpdateAsync(o => o.SetProperty(p => p.LastLogin, date));
        await db.SaveChangesAsync();
    }
}
