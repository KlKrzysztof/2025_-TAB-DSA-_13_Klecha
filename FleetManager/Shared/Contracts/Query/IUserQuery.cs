using Shared.Models;

namespace Shared.Contracts.Query;

public interface IUserQuery
{
    public Task<List<User>> GetUserAsync();

    public Task<User?> GetUserByIdAsync(int id);

    public Task<User?> GetUserByEmployeeIdAsync(int id);

    public Task CreateUserAsync(User user);

    public Task UpdateUserAsync(User user);

    public Task DeleteUserAsync(int id);
}